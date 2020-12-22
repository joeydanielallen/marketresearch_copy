using afmr.model.Research;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static TemplateQuestion Map(this data.Models.Template.SectionQuestion data, bool canSectionRepeat)
        {
            if (data == null) return null;
            var model = new TemplateQuestion();

            model.AllowMultipleSelectAnswers = data.Question.QuestionType.HasMultipleSelection;
            model.AnswerType = (AnswerType)data.Question.QuestionTypeId;
            model.Description = data.Question.Description;
            model.Id = data.Id;
            model.MaxLength = data.Question.MaxLength;
            model.Name = data.Question.Name;
            model.OrderIndex = data.OrderIndex;
            if (canSectionRepeat)
            {
                model.GroupIndex = 0;
            }
            model.QuestionAnswers = data.Question.CustomSelectAnswers.Select(e => e.Map());

            return model;
        }
    }
}
