using afmr.model.Research;
using System.Collections.Generic;

namespace afmr.domain.Internal.Models.Odysseus
{
    public class NationalStockNumber
    {
        public int NationalStockNumberId { get; set; }

        public string Number { get; set; }

        //public DateTime CreationDate { get; set; }

        public string Nomenclature { get; set; }

        /// <summary>
        /// Potential bid type from fed data
        /// </summary>
        public BidType BidType { get; set; }

        public FederalSupplyGroup FederalSupplyGroup { get; set; }

        public FederalSupplyClass FederalSupplyClass { get; set; }

        public IEnumerable<Part> VendorParts { get; set; }
    }
}