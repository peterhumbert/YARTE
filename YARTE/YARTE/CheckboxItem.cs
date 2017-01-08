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
        private bool blnCheckd = false;

        public CheckboxItem(string label, string identifier)
        {
            strLabel = label;
            strIdentifier = identifier;
        }

        public CheckboxItem(string label, string identifier, bool checkd) : this(label, identifier)
        {
            blnCheckd = checkd;
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

        public bool Checked
        {
            get { return blnCheckd; }
            set { blnCheckd = value; }
        }
    }
}
