using afmr.data.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Vendors
{
    public interface IVendorNoteRepo
    {
        VendorNote Get(int id);

        void Insert(VendorNote note);

        void Delete(VendorNote note);

        void Update(VendorNote note);
    }
}
