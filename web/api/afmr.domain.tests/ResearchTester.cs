using afmr.data;
using afmr.domain.Security;
using afmr.domain.Services;
using afmr.model;
using afmr.model.Research;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Xunit;

namespace afmr.domain.tests
{
    //  [ExcludeFromCodeCoverage]
    public class ResearchTester
    {
        [Fact]
        public void ValidateStartResearchInactiveTemplate()
        {
            var logger = new Mock<ILogger>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var identity = new Mock<IUserIdentity>();
            var config = new Mock<IConfig>();

            unitOfWork.Setup(m => m.TemplateRepo.Get(It.IsAny<int>())).Returns(new data.Models.Template.Template() { IsActive = false });
            identity.Setup(m => m.UserId).Returns(1);
            identity.Setup(m => m.OrgIds).Returns(new List<int>() { 2 });

            var service = new ResearchService(logger.Object, unitOfWork.Object, identity.Object, config.Object);

            var request = new StartResearchRequest();
            request.FormTemplate = new FormTemplate() { Id = 2, OrgId = 1 };
            request.InitiateResponse = new InitiateResponse();
            request.InitiateResponse.RemainingTemplates = new List<FormTemplate>() { new FormTemplate() { Id = 2 } };
            request.RemainingTemplateReason = "Testing";

            var result = service.ValidateStart(request);
            
            Assert.True(result != null &&
                result.Contains(StartResearchValidation.TemplateIsNotActive),
                "Start Research should validate Template is active"); 
        }

        [Fact]
        public void ValidateStartResearchUserOrgTemplate()
        {
            var service = GetResearchService();
            var request = new StartResearchRequest();
            request.FormTemplate = new FormTemplate() { Id = 1 };
            request.InitiateResponse = new InitiateResponse();
            request.InitiateResponse.RemainingTemplates = new List<FormTemplate>() { new FormTemplate() { Id = 2 } };
            request.RemainingTemplateReason = "Testing";

            var result = service.ValidateStart(request);

            Assert.True(result != null &&
                result.Contains(StartResearchValidation.InvalidUserOrgTemplate),
                "Start Reseaarch should validate FormTemplate Org Id is in User Orgs");
        }

        [Fact]
        public void ValidateStartResearchInitiateHash()
        {
            var logger = new Mock<ILogger>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var identity = new Mock<IUserIdentity>();
            var config = new Mock<IConfig>();

            unitOfWork.Setup(m => m.TemplateRepo.Get(It.IsAny<int>())).Returns(new data.Models.Template.Template() { IsActive = true });
            identity.Setup(m => m.UserId).Returns(1);
            identity.Setup(m => m.OrgIds).Returns(new List<int>() { 2 });

            var service = new ResearchService(logger.Object, unitOfWork.Object, identity.Object, config.Object);

            var request = new StartResearchRequest();
            request.FormTemplate = new FormTemplate() { Id = 2 };
            request.InitiateResponse = new InitiateResponse();
            request.InitiateResponse.RemainingTemplates = new List<FormTemplate>() { new FormTemplate() { Id = 2 } };
            request.RemainingTemplateReason = "Testing";

            var result = service.ValidateStart(request);

            Assert.True(result != null &&
                result.Contains(StartResearchValidation.InvalidInitiateHash),
                "Start Research should validate InitiateResponse Hash");
        }

        [Fact]
        public void ValidateStartResearchUnsuggestedChoice()
        {
            var service = GetResearchService();
            var request = new StartResearchRequest();
            request.FormTemplate = new FormTemplate() { Id = 1 };
            var result = service.ValidateStart(request);

            Assert.True(
                result != null &&
                result.Contains(StartResearchValidation.InitiateResponseNull),
                "Start Research should validate InitiateResponse exists on request");
        }

        [Fact]
        public void ValidateStartResearchInitiateResponse()
        {
            var service = GetResearchService();
            var request = new StartResearchRequest();
            request.FormTemplate = new FormTemplate() { Id = 1 };
            var result = service.ValidateStart(request);

            Assert.True(
                result != null &&
                result.Contains(StartResearchValidation.InitiateResponseNull),
                "Start Research should validate InitiateResponse exists on request");
        }

        [Fact]
        public void ValidateStartResearchFormTemplate()
        {
            var service = GetResearchService();
            var request = new StartResearchRequest();
            var result = service.ValidateStart(request);

            Assert.True(
                result != null &&
                result.Contains(StartResearchValidation.FormTemplateNull),
                "Start Research should validate FormTemplate exists on request");
        }

        private ResearchService GetResearchService()
        {
            var logger = new Mock<ILogger>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var identity = new Mock<IUserIdentity>();
            var config = new Mock<IConfig>();

            identity.Setup(m => m.UserId).Returns(1);
            identity.Setup(m => m.OrgIds).Returns(new List<int>() { 2 });
            unitOfWork.Setup(m => m.TemplateRepo.Get(It.IsAny<int>())).Returns(new data.Models.Template.Template() { IsActive = false });

            return new ResearchService(logger.Object, unitOfWork.Object, identity.Object, config.Object);
        }
    }
}
