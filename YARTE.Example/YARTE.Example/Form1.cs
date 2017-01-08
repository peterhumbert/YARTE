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
                if (item.Value)
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
                temp.Checked = item.Value;
                tasks.TryGetValue(item.Key, out temp); // redefine temp to ensure Dictionary contains up-to-date refs
                output += temp.Label + " " + temp.Checked + "\n";
            }
            MessageBox.Show(output, "Checked Tasks");
        }

        private void btnChangeChecked_Click(object sender, EventArgs e)
        {
            // changes an arbitrary task's checked state
            Random rand = new Random();
            int temp = rand.Next(0, tasks.Count);
            CheckboxItem[] items = new CheckboxItem[10];
            CheckboxItem selected;
            tasks.Values.CopyTo(items,0);
            Console.WriteLine(temp);

            // get a checkbox item from a known identifier
            tasks.TryGetValue(items[temp].Identifier, out selected);
            selected.Checked = !selected.Checked; // local dictionary is up-to-date
            htmlEditor1.updateCheckedState(selected.Identifier, selected.Checked); // update editor
        }

        private void btnGetTasks_Click(object sender, EventArgs e)
        {
            // update the tasks dictionary using the method that returns a
            // dictionary of all ID'd checkboxes. Display labels and 
            // checked states.
            tasks = htmlEditor1.getCheckboxes();
            string output = "";
            foreach (var item in tasks)
            {
                output += item.Value.Label + " " + item.Value.Checked + "\n";
            }

            MessageBox.Show(output, "The current task states");
        }
    }
}
