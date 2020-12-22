using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Account
{
    public class UserAccount : ModelBase
    {
        public UserAccount()
        {
            MarketResearchClaims = new List<string>();
            Orgs = new List<Org>();
        }

        public int UserAccountId { get; set; }

        public string AppKey { get; set; }

        private DateTime _appKeyExpiration;
        public DateTime AppKeyExpiration
        {
            get { return _appKeyExpiration; }
            set { _appKeyExpiration = ValidateUtc(value); }
        }

        public string Email { get; set; }

        private DateTime _expiredOnUtc;
        public DateTime ExpiresOnUtc
        {
            get { return _expiredOnUtc; }
            set
            {
                _expiredOnUtc = ValidateUtc(value);
            }
        }

        public bool IsLockedOut { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// User to data store one way. Encrypted 
        /// </summary>
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        private DateTime _modifiedOnUtc;
        public DateTime ModifiedOnUtc
        {
            get { return _modifiedOnUtc; }
            set
            {
                _modifiedOnUtc = ValidateUtc(value);
            }
        }

        public IEnumerable<string> MarketResearchClaims { get; set; }

        public IEnumerable<Org> Orgs { get; set; }

    }
}
