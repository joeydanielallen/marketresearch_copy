using afmr.domain.Internal.Models.Odysseus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using afmr.model;
using afmr.data;
using afmr.domain.Security;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace afmr.domain.Services
{
    public class OdysseusService : ServiceBase, IOdysseusService
    {
        public OdysseusService(
            ILogger logger,
            IConfig config)
            : base(logger, null, null, config) { }

        public FindNationalStockNumberResponse FindNsn(string nsn)
        {
            var httpResponseMessage = _httpClient.GetAsync(_config.OdysseusApiUrl + "nationalStockNumber/" + nsn).Result;
            if(!httpResponseMessage.IsSuccessStatusCode)
            {
                var response = new FindNationalStockNumberResponse();
                response.NationalStockNumber = null;
                response.NsnToFind = nsn;
                response.ProcessMessage = "Error \n" + httpResponseMessage.StatusCode + " " + httpResponseMessage.ReasonPhrase;
                response.ProcessStatus = ProcessStatus.Error;

                return response;
            }

            return JsonConvert.DeserializeObject<FindNationalStockNumberResponse>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        //queues
        public FindNationalStockNumberResponse FindNsnQueue(string requestId)
        {
            var httpResponseMsg = _httpClient.GetAsync(_config.OdysseusApiUrl + "FindNsnQueue/" + requestId).Result;
            if(!httpResponseMsg.IsSuccessStatusCode)
            {
                var response = new FindNationalStockNumberResponse();
                response.NationalStockNumber = null;
                response.RequestId = requestId;
                response.ProcessMessage = "Error \n" + httpResponseMsg.StatusCode + " " + httpResponseMsg.ReasonPhrase;
                response.ProcessStatus = ProcessStatus.Error;

                return response;
            }

            return JsonConvert.DeserializeObject<FindNationalStockNumberResponse>(httpResponseMsg.Content.ReadAsStringAsync().Result);

        }
    }
}
