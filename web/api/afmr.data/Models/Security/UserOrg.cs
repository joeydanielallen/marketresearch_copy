using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Security
{
    public class UserOrg : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public int OrgId { get; set; }

        [ForeignKey("OrgId")]
        public Org Org { get; set; }

        [ForeignKey("UserAccountId")]
        public UserAccount UserAccount { get; set; }
    }
}
