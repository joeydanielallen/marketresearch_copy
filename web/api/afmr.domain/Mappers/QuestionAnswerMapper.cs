using afmr.model.Research;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static QuestionAnswer Map(this data.Models.Template.CustomSelectAnswer data)
        {
            if (data == null) return null;
            var model = new QuestionAnswer();

            model.Description = data.Description;
            model.Id = data.Id;
            model.Name = data.Name;
            model.OrderIndex = data.OrderIndex;

            return model;
        }
    }
}
