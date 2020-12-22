using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Internal.Models.Sustainment.NSN
{
    public class GetNationalStockNumberResponse
    {
        //public Meta meta { get; set; }

        public int status { get; set; }

        public int NationalStockNumberId { get; set; }

        public string Number { get; set; }

        public string Nomenclature { get; set; }

        public IList<VendorPart> VendorParts { get; set; }

        public FederalSupplyGroup FederalSupplyGroup { get; set; }

        public FederalSupplyClass FederalSupplyClass { get; set; }

        //public IList<IList<object>> raw_bidtype { get; set; }

        public int BidType { get; set; }
    }
}
