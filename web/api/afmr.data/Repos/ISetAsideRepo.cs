using afmr.data.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos
{
    public interface ISetAsideRepo
    {
        IEnumerable<SetAside> GetAll();
    }
}
