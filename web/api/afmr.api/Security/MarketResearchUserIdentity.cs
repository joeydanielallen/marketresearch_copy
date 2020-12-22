using afmr.domain;
using afmr.domain.Security;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace afmr.api.Security
{
    public class MarketResearchUserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _context;

        private readonly UserIdentity _userIdentity;

        public MarketResearchUserIdentity(IHttpContextAccessor context)
        {
            _context = context;

            _userIdentity = new UserIdentity(_context.HttpContext.User);
        }

        public string UserName
        {
            get
            {
                return _userIdentity.UserName;
            }
            set { }
        }
        public string UserKey
        {
            get
            {
                return _userIdentity.UserKey;
            }
            set { }
        }

        public int UserId
        {
            get
            {
                return _userIdentity.UserId;
            }
            set { }
        }

        public IEnumerable<int> OrgIds 
        { 
            get
            {
                return _userIdentity.OrgIds;
            }
            set { }
        }

        public IEnumerable<Claim> GetClaims()
        {
            return _userIdentity.GetClaims();
        }
    }
}
