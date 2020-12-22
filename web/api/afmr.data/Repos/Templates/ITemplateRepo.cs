using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateRepo
    {
        Template Get(int id);

        IEnumerable<Template> GetAll();

        IEnumerable<Template> GetActiveByOrg(IEnumerable<int> orgIds);
    }
}
