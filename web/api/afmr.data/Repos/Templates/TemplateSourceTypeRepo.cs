using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateSourceTypeRepo : RepoBase<TemplateSourceType>, ITemplateSourceTypeRepo
    {
        public TemplateSourceTypeRepo(MarketResearchDbContext dbContext) : base(dbContext) { }
    }
}
