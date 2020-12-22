using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model
{
    public class SearchQueueResponse
    {
        /// <summary>
        /// Unique Id for the request
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Messaging from service finding model (Searching 1 of 10 sources, Error with message, etc.)
        /// </summary>
        public string ProcessMessage { get; set; }

        /// <summary>
        /// Waiting
        /// Processing
        /// Complete 
        /// CompleteNoData
        /// Error
        /// </summary>
        public string ProcessStatusDescription { get; set; }
    }
}
