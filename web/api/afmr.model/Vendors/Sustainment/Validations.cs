using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Validations
    {
        public Validations()
        {
            State = new ValidationState();
            Cage = new ValidationCage();
        }

        public ValidationState State { get; set; }

        public ValidationCage Cage { get; set; }
    }
}
