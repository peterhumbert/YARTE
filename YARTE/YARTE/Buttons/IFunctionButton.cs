using System.Drawing;
using System.Windows.Forms;

namespace YARTE.UI.Buttons
{

    public interface IFunctionButton : IButton
    {
        void IconClicked(HTMLEditorButtonArgs doc, ToolStripButton btn);
    }
}
