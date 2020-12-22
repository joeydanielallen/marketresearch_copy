using afmr.model.Vendors;
using afmr.model.Vendors.Sustainment;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace afmr.domain.Services
{
    public interface IVendorService : IService
    {
        IEnumerable<Vendor> Search(string nameOrCageOrDuns);

        Vendor Get(string vendorId);

        IEnumerable<VendorSearch> SearchByNsn(string nSN, out HttpStatusCode httpStatusCode);

        SustainmentVendor GetVendorDetail(string sustainmentId, out HttpStatusCode httpStatusCode);

        IEnumerable<Vendor> GetRecents(int count);

        void DeleteRecent(int id);

        int AddRecent(int vendorId);

        void DeleteContact(int contactId);

        int AddContact(VendorContact contact);

        VendorContact UpdateContact(VendorContact contact);
    }
}
