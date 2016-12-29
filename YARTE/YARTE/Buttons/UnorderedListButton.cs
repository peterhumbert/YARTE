using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class UnorderedListButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            args.Document.ExecCommand("InsertUnorderedList", false, null);
        }

        public Image IconImage
        {
            get { return Resources.bulletedlist; }
        }

        public string IconName
        {
            get { return "Unordered list"; }
        }

        public string IconTooltip
        {
            get { return "Unordered list"; }
        }

        public string CommandIdentifier
        {
            get { return "InsertUnorderedList"; }
        }
    }
}