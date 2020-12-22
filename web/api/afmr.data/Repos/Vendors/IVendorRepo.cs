using afmr.data.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Vendors
{
    public interface IVendorRepo
    {
        IEnumerable<Vendor> GetByIds(string nameOrCageOrDuns);

        Vendor Get(int id);

        IEnumerable<Vendor> Get(IEnumerable<int> ids);

        Vendor GetBySustainmentId(string sustainmentId);

        IEnumerable<Vendor> Get(IEnumerable<string> cageCodes, IEnumerable<string> dunsIds, IEnumerable<string> names);

        IEnumerable<Vendor> Get(IEnumerable<string> sustainmentIds);

        void Insert(Vendor vendor);
    }
}
