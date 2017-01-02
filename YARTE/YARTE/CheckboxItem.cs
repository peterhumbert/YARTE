using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YARTE
{
    public class CheckboxItem
    {
        private string strLabel;
        private string strIdentifier;

        public CheckboxItem(string label, string identifier)
        {
            strLabel = label;
            strIdentifier = identifier;
        }

        public string Label
        {
            get { return strLabel; }
            set { strLabel = value; }
        }

        public string Identifier
        {
            get { return strIdentifier; }
            set { strIdentifier = value; }
        }
    }
}
