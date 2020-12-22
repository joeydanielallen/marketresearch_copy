using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateSourceTypeRepo
    {
        void Delete(int id);

        void Delete(TemplateSourceType templateSourceType);

        void Insert(TemplateSourceType templateSourceType);
    }
}
