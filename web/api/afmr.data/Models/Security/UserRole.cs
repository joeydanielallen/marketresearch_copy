using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Security
{
    public class UserRole : IEntity
    {
        public int UserRoleId { get; set; }

        public int UserAccountId { get; set; }

        public int AppRoleId { get; set; }

        public virtual AppRole AppRole { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
