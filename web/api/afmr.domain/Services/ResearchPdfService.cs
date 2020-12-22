using afmr.data;
using afmr.data.Models;
using afmr.data.Models.Template;
using afmr.domain.Internal.Models.Odysseus;
using afmr.domain.Internal.Models.Sustainment.NSN;
using afmr.domain.Mappers;
using afmr.domain.Security;
using afmr.model;
using afmr.model.Account;
using afmr.model.Research;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using System.Net.Http.Headers;
using afmr.domain.Internal.Models.Sustainment.PdfService;

namespace afmr.domain.Services
{
    public class ResearchPdfService : ServiceBase, IResearchPdfService
    {
        public ResearchPdfService(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IUserIdentity userIdentity,
            IConfig config)
            : base(logger, unitOfWork, userIdentity, config) { }

        public Stream GetResearchFormPdf(int templateInstanceId)
        {
            var answers = _unitOfWork.TemplateInstanceAnswerRepo.GetByTemplateInstance(templateInstanceId, true, true);
            if(null == answers)
            {
                return null;
            }

            var pdf = answers.MapToRoot();

            var serialized = JsonConvert.SerializeObject(pdf);

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = GetTaskContent(
                GetApiClient()
                .PostAsync(_config.SustainmentPdfServiceUrl, content));

            if(!response.IsSuccessStatusCode)
            {                
                _logger.LogError("Call to PDF Service returned failure. Status Code " + response.ReasonPhrase);
                throw new InvalidOperationException("PDF service call failed");
            }

            var apiReturnStr = GetTaskContent(
                response.Content.ReadAsStringAsync());

            var apiReturn = JsonConvert.DeserializeObject<ServiceResponse>(apiReturnStr);

            var fileName = apiReturn.File;

            BlobServiceClient blobServiceClient = new BlobServiceClient(_config.SustainmentPdfBlobConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_config.SustainmentPdfBlobContainer);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            BlobDownloadInfo download = blobClient.Download();

            return download.Content;
        }
    }
}
