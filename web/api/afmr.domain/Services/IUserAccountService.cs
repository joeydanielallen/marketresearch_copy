using afmr.model.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Services
{
    public interface IUserAccountService : IService
    {
        UserAccount GetUserAccount(string username, string password);

        IEnumerable<UserAccount> GetUsersInOrg(int orgId);

        IEnumerable<UserAccount> GetUsersByName(
            string nameSearchValue,
            int pageNumber,
            int pageSize);
    }
}
