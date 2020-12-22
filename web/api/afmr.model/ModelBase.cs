using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected DateTime ValidateUtc(DateTime value)
        {
            if (value.Kind != DateTimeKind.Utc)
            {
                throw new InvalidTimeZoneException("DateTime must be UTC with format yyyy-MM-ddTHH:mm:ss.FFFZ");
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected DateTime? ValidateUtc(DateTime? value)
        {
            if (value.HasValue && value.Value.Kind != DateTimeKind.Utc)
            {
                throw new InvalidTimeZoneException("DateTime must be UTC with format yyyy-MM-ddTHH:mm:ss.FFFZ");
            }

            return value;
        }
    }
}
