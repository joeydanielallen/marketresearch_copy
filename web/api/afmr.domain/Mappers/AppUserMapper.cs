using afmr.model.Research;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static AppUser MapToAppUser(this data.Models.Security.UserAccount data, int? templateInstanceUserId)
        {
            if (data == null) return null;
            var model = new AppUser();

            model.FirstName = data.FirstName;
            model.Id = data.UserAccountId;
            model.LastName = data.LastName;
            model.TemplateInstanceUserId = templateInstanceUserId;

            return model;
        }
    }
}
