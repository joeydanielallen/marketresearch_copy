using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateInstanceUserRepo
    {
        void Create(TemplateInstanceUser user);

        TemplateInstanceUser Get(int id);

        IEnumerable<TemplateInstanceUser> GetAll(int templateInstanceId, bool includeChildren = true);

        void Delete(int id);

        void Delete(TemplateInstanceUser user);
    }
}
