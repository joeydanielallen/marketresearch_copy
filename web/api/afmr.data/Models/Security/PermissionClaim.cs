using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace afmr.data.Models.Security
{
    public class PermissionClaim : IEntity
    {
        public int PermissionClaimId { get; set; }

        public string ClaimName { get; set; }
    }
}
