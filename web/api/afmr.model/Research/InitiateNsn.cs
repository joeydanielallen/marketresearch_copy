using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class InitiateNsn
    {
        public string Nsn { get; set; }
        
        /// <summary>
        /// Federal Supply Group Description
        /// </summary>
        public string FsgName { get; set; }

        /// <summary>
        /// Federal Supply Class Description
        /// </summary>
        public string FscName { get; set; }

        /// <summary>
        /// Nomenclature
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Material Management Aggregaton Code and Description
        /// </summary>
        public string Mmac { get; set; }
    }
}
