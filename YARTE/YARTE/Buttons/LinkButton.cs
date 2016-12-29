using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class LinkButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            args.Document.ExecCommand("CreateLink", true, null);
        }

        public Image IconImage
        {
            get { return Resources.createlink; }
        }

        public string IconName
        {
            get { return "Create link"; }
        }

        public string IconTooltip
        {
            get { return "Create link"; }
        }

        public string CommandIdentifier
        {
            get { return "CreateLink"; }
        }
    }
}