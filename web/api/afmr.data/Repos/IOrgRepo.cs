using afmr.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Repos
{
    public interface IOrgRepo
    {
        IEnumerable<Org> GetAll(bool includeTemplates);
    }
}
