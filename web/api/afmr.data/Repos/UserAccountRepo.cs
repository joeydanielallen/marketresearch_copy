using afmr.data.Models;
using afmr.data.Models.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos
{
    public class UserAccountRepo : RepoBase<UserAccount>, IUserAccountRepo
    {
        public UserAccountRepo(MarketResearchDbContext dbContext) : base(dbContext) { }
        
        public UserAccount GetUser(string username, string passwordHash)
        {
            return Get()
                .Include(e => e.UserOrgs)
                    .ThenInclude(e => e.Org)
                .Include(e => e.UserRoles)
                    .ThenInclude(c => c.AppRole)
                        .ThenInclude(a => a.RoleClaims)
                .FirstOrDefault(e => e.UserName == username && e.PasswordHash == passwordHash);
        }

        public IEnumerable<UserAccount> SearchUsersByName(string valueInName)
        {
            return Get()
                .Include(e => e.UserOrgs)
                    .ThenInclude(e => e.Org)
                .Where(e =>
                    e.IsActive &&
                    (e.FirstName.Contains(valueInName) ||
                    e.LastName.Contains(valueInName)))
                .OrderBy(e => e.FirstName)
                .ToList();
                
        }
    }
}
