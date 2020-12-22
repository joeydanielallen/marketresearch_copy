using afmr.data.Models.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public interface ITemplateInstanceAnswerRepo
    {
        TemplateInstanceAnswer Get(
            int templateInstanceId, 
            int templateSectionId, 
            int sectionQuestionId, 
            int? multiselectAnswerId);

        IEnumerable<TemplateInstanceAnswer> GetByTemplateInstance(int templateInstanceId, bool includeChildren = true, bool includeTemplateSectionAndCustomAnswers = false);

        IEnumerable<TemplateInstanceAnswer> GetRepeatableSectionAnswers(
               int templateInstanceId,
               int templateSectionId,
               int answerGroupIndex);

        void Save(IEnumerable<TemplateInstanceAnswer> answers);

        void Save(TemplateInstanceAnswer answer);

        void Delete(TemplateInstanceAnswer answer);

        void Insert(TemplateInstanceAnswer answer);

        void Update(TemplateInstanceAnswer answer);
    }
}
