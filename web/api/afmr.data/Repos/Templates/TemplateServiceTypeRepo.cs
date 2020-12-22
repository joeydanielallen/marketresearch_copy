using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateServiceTypeRepo : RepoBase<TemplateServiceType>, ITemplateServiceTypeRepo
    {
        public TemplateServiceTypeRepo(MarketResearchDbContext dbContext) : base(dbContext) { }
    }
}
