using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Security
{
    public struct MarketResearchClaim
    {
        public MarketResearchClaim(string typeName, string typeId)
        {
            TypeName = typeName;
            TypeId = typeId;
        }
        public string TypeName { get; }
        public string TypeId { get; }
    }
}
