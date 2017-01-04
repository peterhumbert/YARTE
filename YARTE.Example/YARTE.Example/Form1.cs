using System.Collections.Generic;
using System.Windows.Forms;
using YARTE.UI.Buttons;
using System;

namespace YARTE.Example
{
    public partial class Form1 : Form
    {
        //private List<CheckboxItem> tasks = new List<CheckboxItem>();
        private Dictionary<string, CheckboxItem> tasks = new Dictionary<string, CheckboxItem>();

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
        }

        public void AddTask(string label)
        {
            string id = htmlEditor1.insertCheckbox(label);
            tasks.Add(id, new CheckboxItem(label, id));
            //htmlEditor1.InsertTextAtCursor(task.Identifier);
        }

        private void btnDispTasks_Click(object sender, EventArgs e)
        {
            // display all unchecked <INPUT>s
            string output = "";
            foreach (var item in htmlEditor1.getCheckedStates())
            {
                if (item.Value.Equals("True"))
                {
                    output += item.Key + "\n";
                }
            }
            MessageBox.Show(output, "Checked Tasks");

            // update and display the <INPUT>s in tasks
            output = "";
            foreach (var item in htmlEditor1.getCheckedStates())
            {
                CheckboxItem temp;
                tasks.TryGetValue(item.Key, out temp);
                temp.Checked = item.Value.Equals("True");
                tasks.TryGetValue(item.Key, out temp); // redefine temp to ensure Dictionary contains up-to-date refs
                output += temp.Label + " " + temp.Checked + "\n";
            }
            MessageBox.Show(output, "Checked Tasks");
        }
    }
}
