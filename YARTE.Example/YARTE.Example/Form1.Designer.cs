namespace YARTE.Example
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.htmlEditor1 = new YARTE.UI.HtmlEditor();
            this.btnDispHTML = new System.Windows.Forms.Button();
            this.btnAddTodo = new System.Windows.Forms.Button();
            this.btnDispTasks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.htmlEditor1.Html = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">" + 
                "<HTML><HEAD>" +
                "<META content=\"text/html; charset=unicode\" http-equiv=Content-Type>" +
                   "<META name=GENERATOR content=\"MSHTML 11.00.10570.1001\"></HEAD>" +
                      "<BODY></BODY></HTML>";
            this.htmlEditor1.Location = new System.Drawing.Point(0, 0);
            this.htmlEditor1.Margin = new System.Windows.Forms.Padding(4);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.ReadOnly = false;
            this.htmlEditor1.ShowToolbar = true;
            this.htmlEditor1.Size = new System.Drawing.Size(723, 395);
            this.htmlEditor1.TabIndex = 0;
            // 
            // btnDispHTML
            // 
            this.btnDispHTML.Location = new System.Drawing.Point(599, 398);
            this.btnDispHTML.Name = "btnDispHTML";
            this.btnDispHTML.Size = new System.Drawing.Size(94, 23);
            this.btnDispHTML.TabIndex = 1;
            this.btnDispHTML.Text = "Disp HTML";
            this.btnDispHTML.UseVisualStyleBackColor = true;
            this.btnDispHTML.Click += new System.EventHandler(this.btnDispHTML_Click);
            // 
            // btnAddTodo
            // 
            this.btnAddTodo.Location = new System.Drawing.Point(503, 398);
            this.btnAddTodo.Name = "btnAddTodo";
            this.btnAddTodo.Size = new System.Drawing.Size(90, 23);
            this.btnAddTodo.TabIndex = 2;
            this.btnAddTodo.Text = "Add Todo";
            this.btnAddTodo.UseVisualStyleBackColor = true;
            this.btnAddTodo.Click += new System.EventHandler(this.btnAddTodo_Click);
            // 
            // btnDispTasks
            // 
            this.btnDispTasks.Location = new System.Drawing.Point(407, 398);
            this.btnDispTasks.Name = "btnDispTasks";
            this.btnDispTasks.Size = new System.Drawing.Size(90, 23);
            this.btnDispTasks.TabIndex = 3;
            this.btnDispTasks.Text = "Disp Tasks";
            this.btnDispTasks.UseVisualStyleBackColor = true;
            this.btnDispTasks.Click += new System.EventHandler(this.btnDispTasks_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 433);
            this.Controls.Add(this.btnDispTasks);
            this.Controls.Add(this.btnAddTodo);
            this.Controls.Add(this.btnDispHTML);
            this.Controls.Add(this.htmlEditor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.HtmlEditor htmlEditor1;
        private System.Windows.Forms.Button btnDispHTML;
        private System.Windows.Forms.Button btnAddTodo;
        private System.Windows.Forms.Button btnDispTasks;
    }
}

