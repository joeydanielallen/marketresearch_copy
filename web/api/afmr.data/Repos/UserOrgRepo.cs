using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos
{
    public class UserOrgRepo : RepoBase<Models.Security.UserOrg>, IUserOrgRepo
    {
        public UserOrgRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Models.Security.UserOrg> GetByUserAccount(int userAccountId)
        {
            return Get()
                .Where(e => e.UserAccountId == userAccountId)
                .ToList();
        }

        public IEnumerable<Models.Security.UserOrg> GetByOrg(int orgId)
        {
            return Get()
                .Include(e => e.UserAccount)
                .Where(e => e.OrgId == orgId)
                .ToList();
        }

        public Models.Security.UserOrg Get(int id)
        {
            return Get()
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }
    }
}
