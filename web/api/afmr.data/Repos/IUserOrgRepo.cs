using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos
{
    public interface IUserOrgRepo
    {
        IEnumerable<Models.Security.UserOrg> GetByUserAccount(int userAccountId);

        IEnumerable<Models.Security.UserOrg> GetByOrg(int orgId);

        Models.Security.UserOrg Get(int id);

        void Delete(int id);

        void Delete(Models.Security.UserOrg entity);
    }
}
