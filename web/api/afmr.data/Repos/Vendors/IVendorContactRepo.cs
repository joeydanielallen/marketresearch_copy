using afmr.data.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Vendors
{
    public interface IVendorContactRepo
    {
        VendorContact Get(int id);

        // IEnumerable<VendorContact> GetByVendorId(int vendorId);

        void Delete(int id);

        void Insert(VendorContact entity);

        void Update(VendorContact entity);
    }
}
