using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace afmr.model.Security
{
    public class MarketResearchClaims
    {
        //TODO Add more Claim types
        public const string StartMarketResearch = "7";
        public const string InitiateMarketResearch = "6";
        public const string ViewMarketResearch = "5";

        public const string Orgs = "4";//skip PermissionClaim

        public const string UserId = "3";
        public const string Username = "2";
        public const string AppKey = "1";

        public static IEnumerable<MarketResearchClaim> GetClaims()
        {
            return typeof(MarketResearchClaims)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .Select(x => new MarketResearchClaim(x.Name, (string)x.GetRawConstantValue()))
                .ToList();
        }
    }
}
