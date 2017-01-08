using System.Drawing;
using YARTE.Properties;
using System;

namespace YARTE.UI.Buttons
{
    public class CheckboxButton : IHTMLEditorButton
    {
        public void IconClicked(ButtonArgs args)
        {
            args.Editor.insertCheckbox();            
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
