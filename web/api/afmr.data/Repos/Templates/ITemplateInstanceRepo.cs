using afmr.data.Models;
using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateInstanceRepo
    {
        TemplateInstance Get(int id, bool includeChildren = true);

        TemplateInstance GetForDelete(int id);

        void Update(TemplateInstance templateInstance);

        void Create(TemplateInstance templateInstance);

        void Delete(TemplateInstance templateInstance);

        IEnumerable<TemplateInstance> GetByNSN(string nsn);

        IEnumerable<TemplateInstance> GetByUserId(int userId);

        IEnumerable<TemplateInstance> GetInProgressForUser(int userId);

        IEnumerable<TemplateSection> GetTemplateQuestions(int templateInstanceId);
    }
}
