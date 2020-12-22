using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateInitiateVendorRepo : RepoBase<TemplateInitiateVendor>, ITemplateInitiateVendorRepo
    {
        public TemplateInitiateVendorRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public void Create(TemplateInitiateVendor vendor)
        {
            base.Insert(vendor);
        }

        public IEnumerable<TemplateInitiateVendor> Get(int templateInstaneId)
        {
            var instances = Get().Where(e => e.TemplateInstanceId == templateInstaneId).ToList();

            return instances;
        }
    }
}
