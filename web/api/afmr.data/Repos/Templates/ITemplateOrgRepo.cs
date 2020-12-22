using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateOrgRepo
    {
        void Delete(int id);

        void Delete(TemplateOrg templateOrg);

        void Insert(TemplateOrg template);
    }
}
