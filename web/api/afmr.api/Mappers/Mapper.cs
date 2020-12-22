using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api.Mappers
{
    public static partial class Mapper
    {
        //Member here are for common mapping behaviors

        public static DateTime SetUtcDateTimeKind(DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
    }
}
