using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public enum AnswerType
    {
        SmallText = 1,
        LargeText,
        Date,
        Number,
        Select,
        VendorSelect,
        MultiSelect,
        Currency,
        Identifier
    }
}
