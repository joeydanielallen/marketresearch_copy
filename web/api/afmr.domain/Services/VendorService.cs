using afmr.data;
using afmr.data.Models;
using afmr.domain.Internal.Models.Sustainment.Vendors;
using afmr.domain.Mappers;
using afmr.domain.Security;
using afmr.model;
using afmr.model.Vendors;
using afmr.model.Vendors.Sustainment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace afmr.domain.Services
{
    public class VendorService : ServiceBase, IVendorService
    {
        public VendorService(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IUserIdentity userIdentity,
            IConfig config)
            : base(logger, unitOfWork, userIdentity, config) { }

        public IEnumerable<Vendor> Search(string nameOrCageOrDuns)
        {
            IEnumerable<afmr.data.Models.Vendors.Vendor> vendors = null;

            using (_unitOfWork)
            {
                vendors = _unitOfWork.VendorRepo.GetByIds(nameOrCageOrDuns);
            };

            if (!vendors.Any())
            {
                return new List<Vendor>();
            }

            return vendors.Map();
        }

        public IEnumerable<VendorSearch> SearchByNsn(string nSN, out HttpStatusCode httpStatusCode)
        {
            if (null == nSN)
            {
                throw new ArgumentNullException(nameof(nSN));
            }

            var nsnToFind = nSN.Substring(0, 13);

            var httpResponseMessage = GetTaskContent(
                GetApiClient(false)
                .GetAsync(_config.SustainmentApiNsnToVendorUrl + nSN));

            httpStatusCode = httpResponseMessage.StatusCode;

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogError("Searching vendors by nsn (" + nSN + ") failed with status code " + httpResponseMessage.StatusCode);

                return null;
            }

            var content = GetTaskContent(
                httpResponseMessage.Content.ReadAsStringAsync());

            var data = JsonConvert.DeserializeObject<VendorSearchByNsn>(content);

            var vendors = data.Results
                .Take(50) //TODO drive from configuration, default to app config, later for org and/or profile
                .Map();

            MergeData(vendors);

            return vendors;
        }

        public Vendor Get(string vendorId)
        {
            Vendor vendor = null;

            // This could be an error if the number of vendors in the MR DB grows to larger than 10,000,000

            if (!vendorId.StartsWith("0") && int.TryParse(vendorId, out var mrId))
            {
                vendor = _unitOfWork.VendorRepo.Get(mrId).Map();
            }

            if (null == vendor)
            {
                vendor = _unitOfWork.VendorRepo.GetBySustainmentId(vendorId).Map();
            }
            using (_unitOfWork)
            {
                if (null == vendor)
                {
                    vendor = CreateNewVendorFromSustainment(vendorId);
                }

                if (null != vendor)
                {
                    var recent = new RecentUserVendor();
                    recent.CreatedOnUtc = DateTime.UtcNow;
                    recent.UserAccountId = _userIdentity.UserId;
                    recent.VendorId = vendor.Id;

                    _unitOfWork.RecentUserVendorRepo.Insert(recent);
                    _unitOfWork.Save();
                }
            }

            return vendor;
        }

        public SustainmentVendor GetVendorDetail(string sustainmentId, out HttpStatusCode httpStatusCode)
        {
            if (string.IsNullOrEmpty(sustainmentId))
            {
                throw new ArgumentNullException(nameof(sustainmentId));
            }

            var httpResponseMessage = GetTaskContent(
                GetApiClient(false)
                .GetAsync(string.Format(_config.SustainmentVendorDetailApiUrl, sustainmentId)));

            httpStatusCode = httpResponseMessage.StatusCode;

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogError("Searching vendor detail (" + sustainmentId + ") failed with status code " + httpResponseMessage.StatusCode);

                return null;
            }

            var content = GetTaskContent(
                httpResponseMessage.Content.ReadAsStringAsync());

            var vendor = JsonConvert.DeserializeObject<SustainmentVendor>(content);

            return vendor;
        }

        public IEnumerable<Vendor> GetRecents(int count)
        {
            return _unitOfWork.RecentUserVendorRepo.Get(_userIdentity.UserId, count > 0 ? count : 10)
                .Select(e => e.Vendor)
                .Map()
                .ToList();
        }

        public void DeleteRecent(int id)
        {
            using (_unitOfWork)
            {
                _unitOfWork.RecentUserVendorRepo.Delete(id);
                _unitOfWork.Save();
            }
        }

        public int AddRecent(int vendorId)
        {
            var recent = new RecentUserVendor();
            recent.CreatedOnUtc = DateTime.UtcNow;
            recent.UserAccountId = _userIdentity.UserId;
            recent.VendorId = vendorId;

            using (_unitOfWork)
            {
                _unitOfWork.RecentUserVendorRepo.Insert(recent);
                _unitOfWork.Save();
            }

            return recent.Id;
        }

        private Vendor CreateNewVendorFromSustainment(string vendorId)
        {
            var sustainmentVendor = GetVendorDetail(vendorId, out var httpStatusCode);

            if (httpStatusCode != HttpStatusCode.OK &&
                httpStatusCode != HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Sustainment vendor detail API call failed with status of " + httpStatusCode.ToString());
            }

            if (sustainmentVendor == null)
            {
                return null;
            }

            var newVendor = new data.Models.Vendors.Vendor();
            newVendor.CAGECode = sustainmentVendor?.Ids.CAGE;
            newVendor.DUNSId = sustainmentVendor?.Ids.DUNS;
            newVendor.SustainmentId = sustainmentVendor.Vendor_id;
            newVendor.Name = sustainmentVendor.Names.Legal ??
                sustainmentVendor.Names.Profile ??
                sustainmentVendor.Names.DBAs.FirstOrDefault() ??
                sustainmentVendor.Names.AKAs.FirstOrDefault() ??
                string.Empty;

            _unitOfWork.VendorRepo.Insert(newVendor);

            return newVendor.Map();
        }

        public void DeleteContact(int contactId)
        {
            using (_unitOfWork)
            {
                _unitOfWork.VendorContactRepo.Delete(contactId);
                _unitOfWork.Save();
            }
        }

        public int AddContact(VendorContact contact)
        {
            var data = new data.Models.Vendors.VendorContact();
            data.AddressLine1 = contact.AddressLine1;
            data.AddressLine2 = contact.AddressLine2;
            data.City = contact.City;
            data.Email = contact.Email;
            data.Name = contact.Name;
            data.Phone = contact.Phone;
            data.PostalCode = contact.PostalCode;
            data.SavedByUserAccountId = _userIdentity.UserId;
            data.SavedOnUtc = DateTime.UtcNow;
            data.StateAbbreviation = contact.StateAbbreviation;
            data.VendorId = contact.VendorId;

            using (_unitOfWork)
            {

                _unitOfWork.VendorContactRepo.Insert(data);
                _unitOfWork.Save();

            };

            return data.Id;
        }

        public VendorContact UpdateContact(VendorContact contact)
        {
            using (_unitOfWork)
            {
                var data = _unitOfWork.VendorContactRepo.Get(contact.Id);
                if(data == null)
                {
                    return null;
                }

                data.AddressLine1 = contact.AddressLine1;
                data.AddressLine2 = contact.AddressLine2;
                data.City = contact.City;
                data.Email = contact.Email;
                data.Name = contact.Name;
                data.Phone = contact.Phone;
                data.PostalCode = contact.PostalCode;
                data.SavedByUserAccountId = _userIdentity.UserId;
                data.SavedOnUtc = DateTime.UtcNow;
                data.StateAbbreviation = contact.StateAbbreviation;
                data.VendorId = contact.VendorId;

                _unitOfWork.VendorContactRepo.Update(data);
                _unitOfWork.Save();
                return contact;
            };
        }

        private void MergeData(IEnumerable<VendorSearch> vendors)
        {
            var sustainmentIds = vendors.Select(e => {
                return e.SustainmentVendorId.Length < 9 && (e.SustainmentVendorId.PadLeft(9, '0') == e.DUNSId) ?
                e.DUNSId :
                e.SustainmentVendorId;
            }).ToList();

            var mrVendors = _unitOfWork.VendorRepo.Get(sustainmentIds);

            foreach (var item in vendors)
            {
                var mrVendor = mrVendors.FirstOrDefault(e => e.SustainmentId == item.SustainmentVendorId);
                if (null != mrVendor)
                {
                    item.ResearchVendorId = mrVendor.Id;
                }
            }
        }
    }
}
