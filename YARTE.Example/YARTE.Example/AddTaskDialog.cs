using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YARTE.Example
{
    public partial class AddTaskDialog : Form
    {
        private Form1 frmParent;

        public AddTaskDialog(Form1 parent)
        {
            InitializeComponent();
            frmParent = parent;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
        }
    }
}
