using System;
using System.Collections.Generic;
using System.Text;

namespace Cedid.AkilliLojistik.Attribute
{
    public class ParamaterRefAttribute : System.Attribute
    {
        public string ReferanceProperty { get; set; }
        public string[] TargetColumns { get; set; }
        public ParamaterRefAttribute(string referanceProperty, params string[] targetColumns)
        {
            ReferanceProperty = referanceProperty;
            TargetColumns = targetColumns;
        }
    }
}
