using afmr.data.Models.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateInstanceAnswerRepo : RepoBase<TemplateInstanceAnswer>, ITemplateInstanceAnswerRepo
    {
        public TemplateInstanceAnswerRepo(MarketResearchDbContext dbContext) : base(dbContext) { }
        
        public TemplateInstanceAnswer Get(
            int templateInstanceId, 
            int templateSectionId, 
            int sectionQuestionId, 
            int? multiselectAnswerId)
        {
            if (!multiselectAnswerId.HasValue)
            {
                return Get()
                    .Where(e => e.TemplateInstanceId == templateInstanceId && 
                    e.TemplateSectionId == templateSectionId && 
                    e.SectionQuestionId == sectionQuestionId)
                    .FirstOrDefault();
            }

            return Get()
                    .Where(e => e.TemplateInstanceId == templateInstanceId &&
                    e.TemplateSectionId == templateSectionId &&
                    e.SectionQuestionId == sectionQuestionId &&
                    e.AnswerValue == multiselectAnswerId.Value.ToString())
                    .FirstOrDefault();
        }

        public IEnumerable<TemplateInstanceAnswer> GetByTemplateInstance(int templateInstanceId, bool includeChildren=true, bool includeTemplateSectionAndCustomAnswers = false)
        {
            if(includeChildren)
            {
                IQueryable<TemplateInstanceAnswer> query;

                if(includeTemplateSectionAndCustomAnswers)
                {
                    query = Get()
                        .Include(e => e.TemplateSection)
                        .Include(e => e.SectionQuestion)
                            .ThenInclude(e => e.Question)
                                .ThenInclude(e => e.QuestionType)
                        .Include(e => e.SectionQuestion)
                            .ThenInclude(e => e.Question)
                                .ThenInclude(e => e.CustomSelectAnswers);
                }
                else
                {
                    query = Get()
                        .Include(e => e.SectionQuestion)
                            .ThenInclude(e => e.Question)
                                .ThenInclude(e => e.QuestionType);
                }

                return query.Where(e => e.TemplateInstanceId == templateInstanceId)
                .ToList();
            }

            return Get()
                .Where(e => e.TemplateInstanceId == templateInstanceId)
                .ToList();
        }

        public IEnumerable<TemplateInstanceAnswer> GetRepeatableSectionAnswers(
            int templateInstanceId, 
            int templateSectionId, 
            int answerGroupIndex)
        {
            return Get()
                .Where(e =>
                e.TemplateInstanceId == templateInstanceId &&
                e.TemplateSectionId == templateSectionId &&
                e.AnswerGroupIndex == answerGroupIndex)
                .ToList();
        }

        public void Save(IEnumerable<TemplateInstanceAnswer> answers)
        {
            if(answers != null &&
                answers.Any())
            {
                var answersArray = answers.ToArray();
                for (int index = 0; index < answersArray.Length; index++)
                {
                    var answer = answersArray[index];
                    Save(answer);
                }
            }
        }

        public void Save(TemplateInstanceAnswer answer)
        {
            if (answer.Id == 0)
            {
                base.Insert(answer);
            }
            else if (answer.Id > 0)
            {
                base.Update(answer);
            }
        }
    }
}
