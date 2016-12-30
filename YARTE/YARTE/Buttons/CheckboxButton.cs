using System.Drawing;
using YARTE.Properties;
using System;

namespace YARTE.UI.Buttons
{
    public class CheckboxButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            Random t = new Random();
            string valueToReplace = t.Next().ToString();
            args.Editor.InsertTextAtCursor(valueToReplace); // place random int in checkbox's position
            string html = args.Editor.Html;
            html = html.Replace(valueToReplace, "<input type=\"checkbox\">"); // place checkbox
            args.Editor.Html = html; // reload
        }

        public Image IconImage
        {
            get
            {
                return Resources.insertcheckbox;
            }
        }

        public string IconName
        {
            get { return "Insert Checkbox"; }
        }

        public string IconTooltip
        {
            get { return "Insert Checkbox"; }
        }

        public string CommandIdentifier
        {
            get { return ""; }
        }
    }
}
