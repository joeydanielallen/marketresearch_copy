using afmr.model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace afmr.domain.Security
{

    public class UserIdentity : IUserIdentity
    {
        private readonly ClaimsPrincipal _claimsPrincipal;

        public UserIdentity(ClaimsPrincipal claimsPrincipal = null)
        {
            OrgIds = new List<int>();

            if (claimsPrincipal != null)
            {
                _claimsPrincipal = claimsPrincipal;
                if (claimsPrincipal.Claims.Any())
                {
                    UserName = GetClaimValue(MarketResearchClaims.Username);
                    UserKey = GetClaimValue(MarketResearchClaims.AppKey);
                    UserId = GetClaimInt(MarketResearchClaims.UserId);
                    OrgIds = GetOrgClaims();
                }
            }
        }

        public string UserName { get; set; }

        public string UserKey { get; set; }

        public int UserId { get; set; }

        public IEnumerable<int> OrgIds { get; set; }

        public IEnumerable<Claim> GetClaims()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(MarketResearchClaims.UserId, UserId.ToString()));
            claims.Add(new Claim(MarketResearchClaims.AppKey, UserKey));
            claims.Add(new Claim(MarketResearchClaims.Username, UserName));
            foreach (var item in OrgIds)
            {
                claims.Add(new Claim(MarketResearchClaims.Orgs, item.ToString()));
            }

            return claims;
        }

        private List<int> GetOrgClaims()
        {
            var orgIds = new List<int>();
            var orgClaims = _claimsPrincipal.Claims.Where(e => e.Type == MarketResearchClaims.Orgs);
            if (orgClaims.Any())
            {
                orgIds = orgClaims.Select(e => int.Parse(e.Value)).ToList();
            }
            return orgIds;
        }

        private string GetClaimValue(string claimType)
        {
            var claim = _claimsPrincipal.Claims.FirstOrDefault(c => c.Type == claimType);
            if (null != claim)
            {
                return claim.Value;
            }

            return null;
        }

        private int GetClaimInt(string claimType)
        {
            string value = GetClaimValue(claimType);
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (int.TryParse(value, out var intValue))
                {
                    return intValue;
                }
            }
            throw new InvalidOperationException("Converting claim " + claimType + " to integer failed");
        }
    }
}
