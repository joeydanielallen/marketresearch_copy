using afmr.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos
{
    public interface IMaterialMgmtAggregateCodeRepo
    {
        MaterialMgmtAggregateCode GetMmac(string mmac);
    }
}
