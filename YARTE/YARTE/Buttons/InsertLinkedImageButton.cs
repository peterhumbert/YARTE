using System.Drawing;
using Microsoft.VisualBasic;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class InsertLinkedImageButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            var x = args.Editor.Location.X + 10;
            var y = args.Editor.Location.Y + 10;
            
            var url = Interaction.InputBox("Please enter an image url", "URL", null, x, y);
            if (!string.IsNullOrEmpty(url))
            {
                args.Document.ExecCommand("InsertImage", false, url);
            }
        }

        public Image IconImage
        {
            get { return Resources.insertimage; }
        }

        public string IconName
        {
            get { return "Linked image"; }
        }

        public string IconTooltip
        {
            get { return "Linked image"; }
        }

        public string CommandIdentifier
        {
            get { return "InsertImage"; }
        }
    }
}