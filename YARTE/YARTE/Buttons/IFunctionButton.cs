using System.Drawing;
using System.Windows.Forms;

namespace YARTE.UI.Buttons
{

    public interface IFunctionButton : IButton
    {
        void IconClicked(ButtonArgs doc, ToolStripButton btn);
        string Label { get; set; }
    }
}
