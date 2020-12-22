using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateBidTypeRepo : RepoBase<TemplateBidType>, ITemplateBidTypeRepo
    {
        public TemplateBidTypeRepo(MarketResearchDbContext dbContext) : base(dbContext) { }
    }
}
