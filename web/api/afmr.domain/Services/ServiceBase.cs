using afmr.data;
using afmr.domain.Security;
using afmr.model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace afmr.domain.Services
{
    public abstract class ServiceBase : IService
    {
        private bool disposed = false;
        protected readonly ILogger _logger;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IUserIdentity _userIdentity;
        protected readonly IConfig _config = null;
        protected static HttpClient _httpClient;
        protected static HttpClient _pdfHttpClient;

        public ServiceBase(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IUserIdentity userIdentity,
            IConfig config = null)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userIdentity = userIdentity;
            _config = config;

        }

        protected HttpClient GetApiClient(bool includeBearerToken = false)
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
            }

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (includeBearerToken)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config.OdysseusApiKey);
            }
            
            return _httpClient;
        }

        protected K GetTaskContent<K>(System.Threading.Tasks.Task<K> task) //where K : new()
        {
            task.Wait();
            return task.Result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
