using afmr.domain.Internal.Models.Sustainment.Vendors;
using afmr.domain.Security;
using afmr.model.Account;
using afmr.model.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static IEnumerable<Vendor> Map(this IEnumerable<data.Models.Vendors.Vendor> data)
        {
            if (data == null) return null;
            var model = new List<Vendor>();

            foreach (var item in data)
            {
                model.Add(item.Map());
            }

            return model;
        }
        public static Vendor Map(this data.Models.Vendors.Vendor data)
        {
            if (data == null) return null;

            var vendor = new Vendor();
            vendor.AddressLine1 = data.AddressLine1;
            vendor.AddressLine2 = data.AddressLine2;
            vendor.CAGECode = data.CAGECode;
            vendor.Capability = data.Capability;
            vendor.City = data.City;
            vendor.DUNSId = data.DUNSId;
            vendor.Id = data.Id;
            vendor.Name = data.Name;
            vendor.PastPerformance = data.PastPerformance;
            vendor.PostalCode = data.PostalCode;
            vendor.SetAside = data.SetAside == null ? null : new SetAside()
            {
                Description = data.SetAside.Description,
                Id = data.SetAside.Id,
                Name = data.SetAside.Name
            };
            vendor.SetAsideId = data.SetAsideId;
            vendor.StateAbbreviation = data.StateAbbreviation;
            vendor.SustainmentId = data.SustainmentId;

            var vendorContacts = new List<VendorContact>();
            if (data.VendorContacts != null && data.VendorContacts.Any())
            {
                foreach (var contact in data.VendorContacts)
                {
                    var newContact = new VendorContact();
                    newContact.AddressLine1 = contact.AddressLine1;
                    newContact.AddressLine2 = contact.AddressLine2;
                    newContact.City = contact.City;
                    newContact.Email = contact.Email;
                    newContact.Id = contact.Id;
                    newContact.Name = contact.Name;
                    newContact.Phone = contact.Phone;
                    newContact.PostalCode = contact.PostalCode;
                    newContact.StateAbbreviation = contact.StateAbbreviation;
                    newContact.VendorId = contact.VendorId;

                    vendorContacts.Add(newContact);
                }
            }
            vendor.VendorContacts = vendorContacts;

            var vendorParts = new List<VendorPart>();
            if (data.VendorParts != null && data.VendorParts.Any())
            {
                foreach (var part in data.VendorParts)
                {
                    var newPart = new VendorPart();
                    newPart.Description = part.Description;
                    newPart.Id = part.Id;
                    newPart.Nsn = part.Nsn;
                    newPart.PartNumber = part.PartNumber;
                    newPart.VendorId = part.VendorId;

                    vendorParts.Add(newPart);
                }
            }
            vendor.VendorParts = vendorParts;

            var vendorNotes = new List<VendorNote>();
            if(data.VendorNotes != null && data.VendorNotes.Any())
            {
                vendorNotes = data.VendorNotes.Map().ToList();
            }

            vendor.VendorNotes = vendorNotes;

            return vendor;
        }

        public static IEnumerable<VendorNote> Map(this IEnumerable<data.Models.Vendors.VendorNote> data)
        {
            if (data == null) return null;
            var model = new List<VendorNote>();

            foreach (var item in data)
            {
                model.Add(item.Map());
            }

            return model;
        }

        public static VendorNote Map(this data.Models.Vendors.VendorNote data)
        {
            if (data == null) return null;

            var model = new VendorNote();
            model.CreatedByAppUser = new UserAccountName()
            {
                FirstName = data.UserAccount.FirstName,
                LastName = data.UserAccount.LastName,
                UserAccountId = data.SavedByUserAccountId
            };
            model.Id = data.Id;
            model.Note = data.Note;
            model.SavedOn = SetUtcDateTimeKind(data.SavedOnUtc);
            model.Title = data.Title;
            model.VendorId = data.VendorId;

            return model;
        }

        public static data.Models.Vendors.VendorNote Map(this VendorNote note, int userId)
        {
            if (note == null)
                return null;

            var data = new data.Models.Vendors.VendorNote();
            data.Id = note.Id;
            data.Note = note.Note;
            data.SavedByUserAccountId = userId;
            data.SavedOnUtc = DateTime.UtcNow;
            data.Title = note.Title;
            data.VendorId = note.VendorId;

            return data;
        }

        public static IEnumerable<VendorSearch> Map(this IEnumerable<VendorByNsn> data)
        {
            if (data == null)
                return null;

            var models = new List<VendorSearch>();

            foreach (var item in data)
            {
                models.Add(item.Map());
            }

            return models;
        }

        public static VendorSearch Map(this VendorByNsn data)
        {
            if (data == null)
                return null;

            var vendor = new VendorSearch();
            vendor.CageCode = data.Cage;
            vendor.DUNSId = data.Duns.PadLeft(9, '0');
            vendor.Name = data.Name;
            vendor.Ranking = data.Score;
            vendor.ResearchVendorId = null;
            vendor.SustainmentVendorId = data.Id.ToString();

            return vendor;
        }
    }
}
