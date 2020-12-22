using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Profile
    {
        public Profile()
        {
            Updated = new ProfileUpdate();
        }

        public string Created { get; set; }
        public ProfileUpdate Updated { get; set; }
    }
}
