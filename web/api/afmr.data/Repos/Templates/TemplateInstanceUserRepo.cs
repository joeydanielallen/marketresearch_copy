using afmr.data.Models;
using afmr.data.Models.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateInstanceUserRepo : RepoBase<TemplateInstanceUser>, ITemplateInstanceUserRepo
    { 
        public TemplateInstanceUserRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public void Create(TemplateInstanceUser user)
        {
            base.Insert(user);
        }

        public TemplateInstanceUser Get(int id)
        {
            return Get()
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<TemplateInstanceUser> GetAll(int templateInstanceId, bool includeChildren = true)
        {
            IEnumerable<TemplateInstanceUser> data = null;

            if (includeChildren)
            {
                data = Get()
                    .Include(e => e.UserAccount)
                    .Where(e => e.TemplateInstanceId == templateInstanceId)
                    .ToList();
            }
            else
            {

                data = Get()
                    .Where(e => e.Id == templateInstanceId)
                    .ToList();
            }

            return data;
        }
    }
}
