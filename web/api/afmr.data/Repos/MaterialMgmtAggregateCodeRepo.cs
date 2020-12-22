using afmr.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos
{
    public class MaterialMgmtAggregateCodeRepo : RepoBase<MaterialMgmtAggregateCode>, IMaterialMgmtAggregateCodeRepo
    {
        public MaterialMgmtAggregateCodeRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public MaterialMgmtAggregateCode GetMmac(string mmac)
        {
            return Get().Where(e => e.Code == mmac).FirstOrDefault();
        }
    }
}
