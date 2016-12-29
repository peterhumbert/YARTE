using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace YARTE.UI.Buttons
{
    public interface IButton
    {
        string IconName { get; }
        string IconTooltip { get; }
    }
}
