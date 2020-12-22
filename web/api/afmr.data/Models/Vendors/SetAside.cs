using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Vendors
{
    public class SetAside : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
