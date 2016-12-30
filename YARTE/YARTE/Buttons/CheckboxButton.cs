using System.Drawing;
using YARTE.Properties;
using System;

namespace YARTE.UI.Buttons
{
    public class CheckboxButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            args.Editor.InsertTextAtCursor("123456789");
            string html = args.Editor.Html;
            html = html.Replace("123456789", "<input type=\"checkbox\">");
            Console.WriteLine(html.ToCharArray()[html.ToCharArray().Length-3]);
            args.Editor.Html = "";
            args.Editor.Html = html;
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
            get { return "Bold"; }
        }
    }
}
