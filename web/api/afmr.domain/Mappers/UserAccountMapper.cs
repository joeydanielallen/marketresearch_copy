using afmr.model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static UserAccount Map(this data.Models.Security.UserAccount data)
        {
            if (data == null) return null;

            var model = new UserAccount();
            model.AppKey = data.AppKey;
            model.Email = data.Email;
            model.ExpiresOnUtc = SetUtcDateTimeKind(data.ExpiresOnUtc);
            model.FirstName = data.FirstName;
            model.IsLockedOut = data.IsLockedOut;
            model.LastName = data.LastName;
            model.ModifiedOnUtc = SetUtcDateTimeKind(data.ModifiedOnUtc);
            //Don't expose the hash
            //model.Password = data.PasswordHash;
            model.UserAccountId = data.UserAccountId;
            model.UserName = data.UserName;

            model.MarketResearchClaims = data.UserRoles.Select(ur => ur.AppRole)
                .Select(approle => approle.RoleClaims)
                .SelectMany(rc => rc)
                .Select(rc => rc.PermissionClaimId.ToString());

            model.Orgs = data.UserOrgs.Select(e => e.Org == null ? null : new afmr.model.Org() { Description = e.Org.Description, Id = e.Org.Id, Name = e.Org.Name });

            return model;
        }
    }
}
