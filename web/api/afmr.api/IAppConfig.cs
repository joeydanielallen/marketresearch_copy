using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api
{
    public interface IAppConfig
    {
        int SessionPersistenceDays { get; set; }
    }
}
