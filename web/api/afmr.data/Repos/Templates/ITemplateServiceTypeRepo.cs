using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateServiceTypeRepo
    {
        void Delete(int id);

        void Delete(TemplateServiceType templateServiceType);

        void Insert(TemplateServiceType templateServiceType);
    }
}
