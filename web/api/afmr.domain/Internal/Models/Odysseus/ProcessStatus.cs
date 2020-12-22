using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Internal.Models.Odysseus
{
    public enum ProcessStatus
    {
        /// <summary>
        /// Waiting to be processed
        /// </summary>
        Waiting = 1,

        /// <summary>
        /// Actively processing
        /// </summary>
        Processing,

        /// <summary>
        /// Work complete with data
        /// </summary>
        Complete,

        /// <summary>
        /// Work complete but no data found for all sources
        /// </summary>
        CompleteNoData,

        /// <summary>
        /// Error occurred during processing
        /// </summary>
        Error
    }
}
