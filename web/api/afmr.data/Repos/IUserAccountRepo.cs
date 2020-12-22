using afmr.data.Models;
using afmr.data.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos
{
    public interface IUserAccountRepo
    {
        UserAccount GetUser(string username, string passwordHash);

        IEnumerable<UserAccount> SearchUsersByName(string valueInName);
    }
}
