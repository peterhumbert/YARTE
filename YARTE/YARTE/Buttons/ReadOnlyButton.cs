using System;
using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class ReadOnlyButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Editor.ReadOnly = !args.Editor.ReadOnly;
        }

        public Image IconImage
        {
            get { return Resources.justifycenter; }
        }

        public string IconName
        {
            get { return "Read Only"; }
        }

        public string IconTooltip
        {
            get { return "Read Only Toggle"; }
        }

        public string CommandIdentifier
        {
            get
            {
                return "JustifyCenter";
            }
        }
    }
}