using System;
using System.Drawing;
using System.Windows.Forms;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class ReadOnlyButton : IFunctionButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Editor.ReadOnly = !args.Editor.ReadOnly;
        }

        public void IconClicked(HTMLEditorButtonArgs args, ToolStripButton button)
        {
            if (button.Text.Equals("Enter Edit Mode"))
            {
                button.Text = "Enter View Mode";
            }
            else
            {
                button.Text = "Enter Edit Mode";
            }
            args.Editor.ReadOnly = !args.Editor.ReadOnly;
        }

        public string IconName
        {
            get { return "Read Only"; }
        }

        public string IconTooltip
        {
            get { return "Read Only Toggle"; }
        }
    }
}