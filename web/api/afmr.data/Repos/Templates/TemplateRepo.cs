using afmr.data.Models;
using afmr.data.Models.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Templates
{
    public class TemplateRepo : RepoBase<Template>, ITemplateRepo
    {
        public TemplateRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public Template Get(int id)
        {
            var temp = Get()
                .Include(e => e.TemplateBidTypes)
                .Include(e => e.TemplateServiceTypes)
                .Include(e => e.TemplateSourceTypes)
                .Include(e => e.TemplateOrgs)
                    .ThenInclude(e => e.Org)
                .Include(e => e.TemplateSections)
                    .ThenInclude(e => e.TemplateSectionGroup)
                .Include(e => e.TemplateSections)
                    .ThenInclude(e => e.Section)
                        .ThenInclude(e => e.SectionQuestions)
                            .ThenInclude(e => e.Question)
                                .ThenInclude(e => e.CustomSelectAnswers)
                .Include(e => e.TemplateSections)
                    .ThenInclude(e => e.Section)
                        .ThenInclude(e => e.SectionQuestions)
                            .ThenInclude(e => e.Question)
                                .ThenInclude(e => e.QuestionType)
                .Where(e => e.Id == id)
                .FirstOrDefault();

            if(temp != null)
            {
                temp.TemplateSections =
                    temp
                    .TemplateSections
                    .OrderBy(e => e.OrderIndex)
                    .ToList();

                var tempSections = temp.TemplateSections.ToArray();
                for (int index = 0; index < tempSections.Length; index++)
                {
                    var tempSection = tempSections[index];
                    if (tempSection.Section.SectionQuestions != null &&
                        tempSection.Section.SectionQuestions.Any())
                    {
                        tempSection.Section.SectionQuestions = tempSection.Section.SectionQuestions.OrderBy(e => e.OrderIndex).ToList();
                    }
                }
            }

            return temp;
        }

        public IEnumerable<Template> GetActiveByOrg(IEnumerable<int> orgIds)
        {
            var activeTemplates = Get()
                .Include(e => e.TemplateBidTypes)
                    .ThenInclude(e => e.BidType)
                .Include(e => e.TemplateOrgs)
                    .ThenInclude(e => e.Org)
                .Include(e => e.TemplateServiceTypes)
                    .ThenInclude(e => e.ServiceType)
                .Include(e => e.TemplateSourceTypes)
                    .ThenInclude(e => e.SourceType)
                .Where(e => e.IsActive && 
                    e.TemplateOrgs.Any(o => orgIds.Contains(o.OrgId)))
                    .ToList();

            return activeTemplates;
        }

        public IEnumerable<Template> GetAll()
        {
            return Get()
                .Include(e => e.TemplateBidTypes)
                    .ThenInclude(e => e.BidType)
                .Include(e => e.TemplateOrgs)
                    .ThenInclude(e => e.Org)
                .Include(e => e.TemplateServiceTypes)
                    .ThenInclude(e => e.ServiceType)
                .Include(e => e.TemplateSourceTypes)
                    .ThenInclude(e => e.SourceType)
                .Include(e => e.TemplateSections)
                    .ThenInclude(e => e.TemplateSectionGroup)
                .Include(e => e.TemplateSections)
                    .ThenInclude(e => e.Section)
                        .ThenInclude(e => e.SectionQuestions)
                            .ThenInclude(e => e.Question)
                                .ThenInclude(e => e.CustomSelectAnswers)
                .ToList()
                .OrderBy(e => e.TemplateSections.OrderBy(k => k.OrderIndex))
                .ThenBy(e => e.TemplateSections.OrderBy(k => k.Section.SectionQuestions.OrderBy(m => m.OrderIndex)))
                .ThenBy(e => e.TemplateSections.OrderBy(k => k.Section.SectionQuestions.OrderBy(m => m.Question.CustomSelectAnswers.OrderBy(n => n.OrderIndex))));
        }

        public IEnumerable<Template> GetByOrgIds(IEnumerable<int> orgIds)
        {
            return Get()
                .Include(e => e.TemplateBidTypes)
                    .ThenInclude(e => e.BidType)
                .Include(e => e.TemplateOrgs.Where(k => orgIds.Contains(k.OrgId)))
                    .ThenInclude(e => e.Org)
                .Include(e => e.TemplateServiceTypes)
                    .ThenInclude(e => e.ServiceType)
                .Include(e => e.TemplateSourceTypes)
                    .ThenInclude(e => e.SourceType)
                .ToList();
        }
    }
}
