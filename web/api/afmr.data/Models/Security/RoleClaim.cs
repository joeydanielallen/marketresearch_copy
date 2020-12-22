using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Security
{
    public class RoleClaim
    {
        public int RoleClaimId { get; set; }

        public int AppRoleId { get; set; }

        public int PermissionClaimId { get; set; }

        public virtual AppRole AppRole { get; set; }

        public virtual PermissionClaim PermissionClaim { get; set; }
    }
}
