using afmr.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api.Models
{
    public class UserAccount
    {
        public UserAccount()
        {
            PermissionClaimValues = new List<string>();
            Orgs = new List<Org>();
        }

        public int UserAccountId { get; set; }

        public DateTime AppKeyExpirationUtc { get; set; }

        public string AppKey { get; set; }

        public IEnumerable<string> PermissionClaimValues { get; set; }

        public DateTime ExpiresOnUtc { get; set; }

        public bool IsLockedOut { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Org> Orgs { get; set; }
    }
}
