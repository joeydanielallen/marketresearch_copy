using afmr.data.Models;
using afmr.data.Models.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateOrgRepo : RepoBase<TemplateOrg>, ITemplateOrgRepo
    {
        public TemplateOrgRepo(MarketResearchDbContext dbContext) : base(dbContext) { }
    }
}
