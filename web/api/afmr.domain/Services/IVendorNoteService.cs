using afmr.model.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Services
{
    public interface IVendorNoteService : IService
    {
        VendorNote Get(int id);

        VendorNote Update(VendorNote note);

        int Create(VendorNote note);

        void Delete(int id);
    }
}
