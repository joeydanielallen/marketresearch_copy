using afmr.model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api
{
    /// <summary>
    /// 
    /// </summary>
    public class Logger : model.ILogger
    {
        private Microsoft.Extensions.Logging.ILogger<Logger> _logger;

        public Logger(Microsoft.Extensions.Logging.ILogger<Logger> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }
            _logger.LogDebug(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void LogInformation(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }
            _logger.LogInformation(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        public void LogError(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                return;
            }

            LogError(null, errorMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public void LogError(Exception exception)
        {
            if(null == exception)
            {
                return;
            }

            LogError(exception, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="errorMessage"></param>
        public void LogError(Exception exception, string errorMessage)
        {
            if (null == exception && string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new InvalidOperationException("Exception and errorMessage do not exist.");
            }

            _logger.LogError(exception, errorMessage);
        }
    }
}
