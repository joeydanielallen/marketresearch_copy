using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class StartResponse
    {
        private IEnumerable<string> _validationErrors;

        public int TemplateInstanceId { get; set; }

        public IEnumerable<string> ValidationErrors 
        { 
            get
            {
                if (_validationErrors == null)
                {
                    _validationErrors = new List<string>();
                }

                return _validationErrors;
            }
            set
            {
                _validationErrors = value;
            }
        }
    }
}
