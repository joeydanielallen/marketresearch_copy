using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models
{
    public class Org : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("OrgId")]
        public IEnumerable<TemplateOrg> TemplateOrgs { get; set; }
    }
}
