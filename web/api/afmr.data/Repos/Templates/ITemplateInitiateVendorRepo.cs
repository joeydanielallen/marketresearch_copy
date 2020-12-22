using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateInitiateVendorRepo
    {
        IEnumerable<TemplateInitiateVendor> Get(int templateInstanceId);

        void Create(TemplateInitiateVendor vendor);

        void Delete(int id);

        void Delete(TemplateInitiateVendor entity);
    }
}
