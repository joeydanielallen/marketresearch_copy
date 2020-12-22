using afmr.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api.Mappers
{
    public static partial class Mapper
    {
        public static UserAccount Map(this model.Account.UserAccount model)
        {
            if (model == null) return null;

            var viewModel = new UserAccount();
            viewModel.AppKey = model.AppKey;
            viewModel.ExpiresOnUtc = model.ExpiresOnUtc;
            viewModel.FirstName = model.FirstName;
            viewModel.IsLockedOut = model.IsLockedOut;
            viewModel.LastName = model.LastName;
            viewModel.UserAccountId = model.UserAccountId;
            viewModel.PermissionClaimValues = model.MarketResearchClaims;
            viewModel.Orgs = model.Orgs;

            return viewModel;
        }

        public static IEnumerable<UserAccount> Map(this IEnumerable<model.Account.UserAccount> model)
        {
            if (model == null) return null;

            return model.Select(e => e.Map());
        }
    }
}
