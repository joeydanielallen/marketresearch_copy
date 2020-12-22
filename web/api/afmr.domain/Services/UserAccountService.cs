using afmr.data;
using afmr.domain.Mappers;
using afmr.domain.Security;
using afmr.model;
using afmr.model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.domain.Services
{
    public class UserAccountService : ServiceBase, IUserAccountService
    {
        public UserAccountService(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IUserIdentity userIdentity)
            : base(logger, unitOfWork, userIdentity)
        {
        }

        public UserAccount GetUserAccount(string username, string password)
        {
            var passwordHash = Hasher.ComputeHash(password, username);
            var model = _unitOfWork.UserAccountRepo.GetUser(username, passwordHash).Map();

            return model;
        }

        public IEnumerable<UserAccount> GetUsersInOrg(int orgId)
        {
            var users = _unitOfWork.UserOrgRepo
                .GetByOrg(orgId)
                .Select(e =>
                {
                    return e.UserAccount.Map();
                });

            return users;
        }

        public IEnumerable<UserAccount> GetUsersByName(
            string nameSearchValue,
            int pageNumber,
            int pageSize)
        {
            var realPage = pageNumber < 1 ? 1 : pageNumber;
            var realPageSize = pageSize < 1 ? 1 : pageSize;
            var skip = (realPage - 1) * realPageSize;

            using (_unitOfWork)
            {
                return _unitOfWork.UserAccountRepo
                    .SearchUsersByName(nameSearchValue)
                    .Skip(skip)
                    .Take(realPageSize)
                    .Select(e => e.Map());
            }
        }
    }
}
