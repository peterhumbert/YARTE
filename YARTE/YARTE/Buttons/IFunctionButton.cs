using System.Drawing;
using System.Windows.Forms;

namespace YARTE.UI.Buttons
{

    public interface IFunctionButton
    {
        void IconClicked(HTMLEditorButtonArgs doc);
        string IconName { get; }
        string IconTooltip { get; }
    }
}
