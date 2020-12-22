using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class TemplateInstanceUser
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
