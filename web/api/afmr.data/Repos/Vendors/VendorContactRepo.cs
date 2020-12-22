using afmr.data.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Vendors
{
    public class VendorContactRepo : RepoBase<VendorContact>, IVendorContactRepo
    {
        public VendorContactRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public VendorContact Get(int id)
        {
            return Get().FirstOrDefault(e => e.Id == id);
        }
    }
}
