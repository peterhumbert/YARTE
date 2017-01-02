using System.Windows.Forms;
using YARTE.UI.Buttons;

namespace YARTE.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            PredefinedButtonSets.SetupDefaultButtons(this.htmlEditor1);
        }

        private void btnDispHTML_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this.htmlEditor1.Html, "The output HTML");
        }

        private void btnAddTodo_Click(object sender, System.EventArgs e)
        {
            htmlEditor1.InsertTextAtCursor("testing");
        }
    }
}
