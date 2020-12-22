using afmr.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static Org Map(this data.Models.Org data)
        {
            if (data == null) return null;

            var model = new Org();

            model.Description = data.Description;
            model.Id = data.Id;
            model.Name = data.Name;

            return model;
        }
    }
}
