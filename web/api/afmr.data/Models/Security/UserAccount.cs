using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Security
{
    public class UserAccount : IEntity
    {
        public UserAccount()
        {
            UserRoles = new List<UserRole>();
            UserOrgs = new List<UserOrg>();
        }

        public int UserAccountId { get; set; }

        public string AppKey { get; set; }

        public string Email { get; set; }

        public DateTime ExpiresOnUtc { get; set; }

        public bool IsLockedOut { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime ModifiedOnUtc { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
        
        public IEnumerable<UserOrg> UserOrgs { get; set; }

        public bool IsActive { get; set; }
    }
}
