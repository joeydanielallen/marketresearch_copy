using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Internal.Models.Odysseus
{
    public class FindNationalStockNumberResponse
    {

        public string NsnToFind { get; set; }

        public NationalStockNumber NationalStockNumber { get; set; }

        /// <summary>
        /// Unique Id for the request
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Authentication Id of user/system
        /// </summary>
        public string UserKey { get; set; }

        /// <summary>
        /// Messaging from service finding model (Searching 1 of 10 sources, Error with message, etc.)
        /// </summary>
        public string ProcessMessage { get; set; }

        /// <summary>
        /// Processing state
        /// </summary>
        public ProcessStatus ProcessStatus { get; set; }
    }
}
