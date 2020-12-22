using afmr.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Recents
{
    public interface IRecentUserVendorRepo
    {
        IEnumerable<RecentUserVendor> Get(int userAccountId, int count);

        void Delete(int id);

        void Insert(RecentUserVendor entity);

        int GetCount(int userAccountId);
    }
}
