using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        //Member here are for common mapping behaviors

        public static DateTime SetUtcDateTimeKind(DateTime dateTime) 
        { 
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);  
        }

        public static DateTime? SetUtcDateTimeKind(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return DateTime.SpecifyKind(dateTime.Value, DateTimeKind.Utc);
        }
    }
}
