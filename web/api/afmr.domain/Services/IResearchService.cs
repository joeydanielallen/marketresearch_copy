using afmr.model.Account;
using afmr.model.Research;
using afmr.model.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Services
{
    public interface IResearchService : IService
    {
        bool CanAnswerResearch(int templateInstanceId);

        InitiateResponse Initiate(InitiateRequest request);

        TemplateInstance Get(int id);

        StartResponse Start(StartResearchRequest request);
        
        void ToggleComplete(int templateInstanceId);

        void Delete(int templateInstanceId);

        void UpdateName(int templateInstanceId, string name);

        IEnumerable<TemplateInstanceSummary> GetSummaries(bool isInProgressOnly = false);

        IEnumerable<model.Research.TemplateInstanceUser> GetUsers(int templateInstanceId);

        void DeleteUser(int templateInstanceUserId);

        int CreateUser(int templateInstanceId, int userAccountId);

        void SaveAnswers(IEnumerable<model.Research.TemplateInstanceAnswer> answers);

        void DeleteMultiselectAnswer(TemplateInstanceAnswer templateInstanceAsnwer, int multiselectAnswerId);

        void DeleteRepeatableSectionAnswers(int templateInstanceId, int templateSectionId, int answerGroupIndex);

        IEnumerable<ResearchFormVendor> GetVendorsSelected(int templateInstanceId);
    }
}
