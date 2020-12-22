using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateBidType : IEntity
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public int BidTypeId { get; set; }

        [ForeignKey(nameof(BidTypeId))]
        public BidType BidType { get; set; }
    }
}
