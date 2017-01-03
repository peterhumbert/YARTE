using System.Collections.Generic;
using System.Windows.Forms;
using YARTE.UI.Buttons;
using System;

namespace YARTE.Example
{
    public partial class Form1 : Form
    {
        private List<CheckboxItem> tasks = new List<CheckboxItem>();

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
            AddTaskDialog atd = new AddTaskDialog(this);
            atd.ShowDialog();

            Console.WriteLine(tasks[0].Label);
        }

        public void AddTask(string label)
        {
            string id = htmlEditor1.insertCheckbox(label);
            tasks.Add(new CheckboxItem(label, id));
            //htmlEditor1.InsertTextAtCursor(task.Identifier);
        }
    }
}
