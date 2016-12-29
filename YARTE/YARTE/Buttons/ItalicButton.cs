using System;
using System.Drawing;
using System.Windows.Forms;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class ItalicButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            args.Document.ExecCommand("Italic", false, null);
        }

        public Image IconImage
        {
            get { return Resources.italic; }
        }

        public string IconName
        {
            get { return "Italic"; }
        }

        public string IconTooltip
        {
            get { return "Italic"; }
        }

        public string CommandIdentifier
        {
            get { return "Italic"; }
        }
    }
}