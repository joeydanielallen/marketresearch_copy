using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateSourceType : IEntity
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public int SourceTypeId { get; set; }

        [ForeignKey(nameof(SourceTypeId))]
        public SourceType SourceType { get; set; }
    }
}
