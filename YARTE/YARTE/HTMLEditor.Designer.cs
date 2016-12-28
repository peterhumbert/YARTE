namespace YARTE.UI
{
    partial class HtmlEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textWebBrowser = new System.Windows.Forms.WebBrowser();
            this.editcontrolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.updateToolBarTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textWebBrowser
            // 
            this.textWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textWebBrowser.Location = new System.Drawing.Point(0, 28);
            this.textWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.textWebBrowser.Name = "textWebBrowser";
            this.textWebBrowser.Size = new System.Drawing.Size(557, 443);
            this.textWebBrowser.TabIndex = 0;
            // 
            // editcontrolsToolStrip
            // 
            this.editcontrolsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.editcontrolsToolStrip.Name = "editcontrolsToolStrip";
            this.editcontrolsToolStrip.Size = new System.Drawing.Size(557, 25);
            this.editcontrolsToolStrip.TabIndex = 1;
            this.editcontrolsToolStrip.Text = "editcontrolsToolStrip";
            // 
            // HtmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editcontrolsToolStrip);
            this.Controls.Add(this.textWebBrowser);
            this.Name = "HtmlEditor";
            this.Size = new System.Drawing.Size(557, 474);
            this.ContextMenuStripChanged += new System.EventHandler(this.HtmlEditor_ContextMenuStripChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser textWebBrowser;
        private System.Windows.Forms.ToolStrip editcontrolsToolStrip;
        private System.Windows.Forms.Timer updateToolBarTimer;
    }
}
