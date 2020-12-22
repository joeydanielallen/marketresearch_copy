using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace afmr.data.Models
{
    public class MaterialMgmtAggregateCode : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string Code { get; set; }

        public bool IsInventoryControlPoint { get; set; }

        public string ActivityCode { get; set; }

        public string Description { get; set; }
    }
}
