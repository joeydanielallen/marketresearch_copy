using afmr.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Recents
{
    public class RecentUserVendorRepo : RepoBase<RecentUserVendor>, IRecentUserVendorRepo
    {
        public RecentUserVendorRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public IEnumerable<RecentUserVendor> Get(int userAccountId, int count)
        {
            return Get()
                .Include(e => e.Vendor)
                .OrderByDescending(e => e.CreatedOnUtc)
                .Where(e => e.UserAccountId == userAccountId)
                .ToList()
                .GroupBy(e => e.VendorId)
                .Select(e => e.First())
                .Take(count)
                .ToList();
        }

        public int GetCount(int userAccountId)
        {
            return Get()
                .Where(e => e.UserAccountId == userAccountId)
                .Count();
        }
    }
}
