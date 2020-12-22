using afmr.data.Models.Vendors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Vendors
{
    public class VendorNoteRepo : RepoBase<VendorNote>, IVendorNoteRepo
    {
        public VendorNoteRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public VendorNote Get(int id)
        {
            return Get()
                .Include(e => e.UserAccount)
                .Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
