using System;
using System.Drawing;
using System.Windows.Forms;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class ReadOnlyButton : IFunctionButton
    {
        private string _label = "Enter View Mode";

        public void IconClicked(ButtonArgs args)
        {
            args.Editor.ReadOnly = !args.Editor.ReadOnly;
        }

        public void IconClicked(ButtonArgs args, ToolStripButton button)
        {
            if (_label.Equals("Enter Edit Mode"))
            {
                _label = "Enter View Mode";
            }
            else
            {
                _label = "Enter Edit Mode";
            }
            button.Text = _label;
            args.Editor.ReadOnly = !args.Editor.ReadOnly;
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public string IconName
        {
            get { return "Read Only"; }
        }

        public string IconTooltip
        {
            get { return _label; }
        }
    }
}