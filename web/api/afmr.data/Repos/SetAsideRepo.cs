using afmr.data.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos
{
    public class SetAsideRepo : RepoBase<SetAside>, ISetAsideRepo
    {
        public SetAsideRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public IEnumerable<SetAside> GetAll()
        {
            return Get().ToList();
        }
    }
}
