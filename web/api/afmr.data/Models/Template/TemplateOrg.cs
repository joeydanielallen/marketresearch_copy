using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateOrg : IEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Template))]
        public int TemplateId { get; set; }

        [ForeignKey(nameof(Org))]
        public int OrgId { get; set; }

        public Org Org { get; set; }

        public Template Template { get; set; }
    }
}
