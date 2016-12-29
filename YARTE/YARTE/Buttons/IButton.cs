using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace YARTE.UI.Buttons
{
    public struct ButtonArgs
    {
        public HtmlDocument Document;
        public HtmlEditor Editor;
    }

    public interface IButton
    {
        string IconName { get; }
        string IconTooltip { get; }
    }
}
