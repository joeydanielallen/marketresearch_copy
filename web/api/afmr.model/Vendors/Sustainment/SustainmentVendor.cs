using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class SustainmentVendor
    {
        public SustainmentVendor ()
        {
            Names = new Names();
            Vendor_id = string.Empty;
            Locations = new Locations();
            Types = new Types();
            Ids = new Ids();
            Ids.State_number = new StateNumber();
            Contacts = new Contacts();
            Validations = new Validations();
            Certifications = new List<Certification>();
            Industries = new IndustryClassification();
            Manufacturing = new Manufacturer();
            Profile = new Profile();
        }

        public string Vendor_id { get; set; }
        public Names Names { get; set; }
        public Ids Ids { get; set; }
        public Locations Locations { get; set; }
        public Types Types { get; set; }
        public Contacts Contacts { get; set; }
        public Validations Validations { get; set; }
        public BusinessSize Size { get; set; }
        public SamFiles Sam_files { get; set; }
        public IEnumerable<Certification> Certifications { get; set; }
        public IndustryClassification Industries { get; set; }
        public Manufacturer Manufacturing { get; set; }

        public Profile Profile { get; set; }

        //public string Id { get; set; }
        //public string _rid { get; set; }
        //public string _self { get; set; }
        //public string _etag { get; set; }
        //public string _attachments { get; set; }
        //public int _ts { get; set; }
    }
}
