using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Security
{
    public class AppRole : IEntity
    {
        public int AppRoleId { get; set; }

        public string AppRoleName { get; set; }

        public IEnumerable<RoleClaim> RoleClaims { get; set; }
    }
}
