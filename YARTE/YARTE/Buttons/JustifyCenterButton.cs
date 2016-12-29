using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class JustifyCenterButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            args.Document.ExecCommand(CommandIdentifier, false, null);
        }

        public Image IconImage
        {
            get { return Resources.justifycenter; }
        }

        public string IconName
        {
            get { return "Justify center"; }
        }

        public string IconTooltip
        {
            get { return "Justify center"; }
        }

        public string CommandIdentifier
        {
            get { return "JustifyCenter"; }
        }
    }
}