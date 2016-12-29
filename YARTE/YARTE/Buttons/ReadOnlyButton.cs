using System;
using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class ReadOnlyButton : IFunctionButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
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