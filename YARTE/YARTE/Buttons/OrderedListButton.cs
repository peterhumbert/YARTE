using System;
using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class OrderedListButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand("InsertOrderedList", false, null);
        }

        public Image IconImage
        {
            get { return Resources.numberedlist; }
        }

        public string IconName
        {
            get { return "Ordered list"; }
        }

        public string IconTooltip
        {
            get { return "Ordered list"; }
        }

        public string CommandIdentifier
        {
            get { return "InsertOrderedList"; }
        }
    }
}