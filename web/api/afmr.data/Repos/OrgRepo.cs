using afmr.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos
{
    public class OrgRepo : RepoBase<Org>, IOrgRepo
    {
        public OrgRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Org> GetAll(bool includeTemplates)
        {
            var query = Get();
            if(includeTemplates)
            {
                query = query.Include(e => e.TemplateOrgs)
                    .ThenInclude(e => e.Template);
            }
            return query.ToList();
        }
    }
}
