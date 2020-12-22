using afmr.domain.Internal.Models.Odysseus;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Services
{
    public interface IOdysseusService
    {
        FindNationalStockNumberResponse FindNsn(string nsn);
    }
}
