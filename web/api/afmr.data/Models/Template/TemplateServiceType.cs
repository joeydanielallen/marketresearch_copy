using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateServiceType : IEntity
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public int ServiceTypeId { get; set; }

        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceType ServiceType { get; set; }
    }
}
