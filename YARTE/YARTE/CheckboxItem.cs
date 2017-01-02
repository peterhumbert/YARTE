using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YARTE
{
    public class CheckboxItem
    {
        private string strLabel;
        private int intIdentifier;

        public CheckboxItem(string label, int identifier)
        {
            strLabel = label;
            intIdentifier = identifier;
        }

        public string Label
        {
            get { return strLabel; }
            set { strLabel = value; }
        }

        public int Identifier
        {
            get { return intIdentifier; }
            set { intIdentifier = value; }
        }
    }
}
