using afmr.data.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Vendors
{
    public class VendorNote : IEntity
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public int SavedByUserAccountId { get; set; }

        public DateTime SavedOnUtc { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        [ForeignKey(nameof(SavedByUserAccountId))]
        public UserAccount UserAccount { get; set; }
    }
}
