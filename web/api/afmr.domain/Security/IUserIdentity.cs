using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Security
{
    public interface IUserIdentity
    {
        string UserName { get; set; }

        string UserKey { get; set; }

        int UserId { get; set; }

        IEnumerable<int> OrgIds { get; set; }
    }
}
