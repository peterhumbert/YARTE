using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using mshtml;
using YARTE.UI.Buttons;
using System.Diagnostics;

namespace YARTE.UI
{
    public partial class HtmlEditor : UserControl
    {
        private readonly HtmlDocument _doc;
        private readonly IList<IButton> _customButtons;

        public HtmlEditor()
        {
            InitializeComponent();

            InitializeWebBrowserAsEditor();

            _doc = textWebBrowser.Document;
            _customButtons = new List<IButton>();

            updateToolBarTimer.Start();
            updateToolBarTimer.Tick += updateToolBarTimer_Tick;
        }

        public void AddFontSizeSelector(IEnumerable<int> fontSizes)
        {
            if (fontSizes.Min() < 1 || fontSizes.Max() > 7)
            {
                throw new ArgumentException("Allowable font sizes are 1 through 7");
            }

            var fontSizeBox = new ToolStripComboBox();
            fontSizeBox.Items.AddRange(fontSizes.Select(f => f.ToString()).ToArray());
            fontSizeBox.Name = "fontSizeSelector";
            fontSizeBox.Size = new System.Drawing.Size(25, 25);
            fontSizeBox.SelectedIndexChanged += (sender, o) =>
            {
                var size = ((ToolStripComboBox)sender).SelectedItem;
                _doc.ExecCommand("FontSize", false, size);
            };
            fontSizeBox.DropDownStyle = ComboBoxStyle.DropDownList;

            this.AddToolbarItem(fontSizeBox);
        }

        public void AddFontSelector(IEnumerable<string> fontNames)
        {
            var dropDown = new ToolStripDropDownButton();
            foreach(var fontName in fontNames)
            {
                dropDown.DropDownItems.Add(GetFontDropDownItem(fontName));
            }
            dropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            dropDown.Name = "Font";
            dropDown.Size = new System.Drawing.Size(29, 22);
            dropDown.Text = "Font";

            this.AddToolbarItem(dropDown);
        }

        private ToolStripItem GetFontDropDownItem(string fontName)
        {
            var dropDownItem = new ToolStripMenuItem();
            dropDownItem.Font = new System.Drawing.Font(fontName, 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dropDownItem.Name = "fontMenuItem" + Guid.NewGuid();
            dropDownItem.Size = new System.Drawing.Size(173, 22);
            dropDownItem.Text = fontName;
            dropDownItem.Click += (sender, e) => _doc.ExecCommand("FontName", false, fontName);
            return dropDownItem;
        }

        public void AddToolbarItem(ToolStripItem toolStripItem)
        {
            editcontrolsToolStrip.Items.Add(toolStripItem);
        }

        public void AddToolbarItems(IEnumerable<ToolStripItem> toolStripItems)
        {
            foreach (var stripItem in toolStripItems)
            {
                editcontrolsToolStrip.Items.Add(stripItem);
            }
        }

        public void AddToolbarItem(IHTMLEditorButton toolbarItem)
        {
            _customButtons.Add(toolbarItem);
            editcontrolsToolStrip.Items.Add(CreateButton(toolbarItem));
        }

        public void AddToolbarItem(IFunctionButton toolbarItem)
        {
            _customButtons.Add(toolbarItem);
            editcontrolsToolStrip.Items.Add(CreateButton(toolbarItem));
        }

        public void AddToolbarItems(IEnumerable<IHTMLEditorButton> toolbarItems)
        {
            foreach (var toolbarItem in toolbarItems)
            {
                AddToolbarItem(toolbarItem);
            }
        }

        public void AddToolbarDivider()
        {
            var divider = new ToolStripSeparator();
            divider.Size = new System.Drawing.Size(6, 25);
            editcontrolsToolStrip.Items.Add(divider);
        }

        private ToolStripItem CreateButton(IHTMLEditorButton toolbarItem)
        {
            var toolStripButton = new ToolStripButton();
            toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton.Image = toolbarItem.IconImage;
            toolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton.Name = toolbarItem.IconName;
            toolStripButton.Size = new System.Drawing.Size(25, 24);
            toolStripButton.Text = toolbarItem.IconTooltip;

            var args = new ButtonArgs();
            args.Document = _doc;
            args.Editor = this;

            IHTMLEditorButton button = toolbarItem;
            toolStripButton.Click += (sender, o) => button.IconClicked(args);

            return toolStripButton;
        }

        private ToolStripItem CreateButton(IFunctionButton toolbarItem)
        {
            var toolStripButton = new ToolStripButton();
            toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton.Name = toolbarItem.IconName;
            toolStripButton.Text = toolbarItem.Label;

            var args = new ButtonArgs();
            args.Document = _doc;
            args.Editor = this;

            IFunctionButton button = toolbarItem;
            toolStripButton.Click += (sender, o) => button.IconClicked(args,toolStripButton);

            return toolStripButton;
        }

        public bool ReadOnly
        {
            get
            {
                if (textWebBrowser.Document != null)
                {
                    var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                    if (doc != null)
                    {
                        return doc.designMode != "On";
                    }
                }
                return false;
            }
            set
            {
                string html = this.Html;
                if (textWebBrowser.Document != null)
                {
                    var designMode = value ? "Off" : "On";
                    var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                    if (doc != null) doc.designMode = designMode;
                }
                if (html != null)
                {
                    this.Html = html;
                }
            }
        }

        public bool ShowToolbar
        {
            get
            {
                if (editcontrolsToolStrip != null)
                {
                    return editcontrolsToolStrip.Visible;
                }
                return true;
            }
            set { editcontrolsToolStrip.Visible = value; }
        }

        private void updateToolBarTimer_Tick(object sender, System.EventArgs e)
        {
            CheckCommandStateChanges();
        }

        private void InitializeWebBrowserAsEditor()
        {
            // It is necessary to add a body to the control before you can apply changes to the DOM document
            textWebBrowser.DocumentText = "<html><body></body></html>";
            if (textWebBrowser.Document != null)
            {
                var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                if (doc != null) doc.designMode = "On";

                // replace the context menu for the web browser control so the default IE browser context menu doesn't show up
                textWebBrowser.IsWebBrowserContextMenuEnabled = false;
                if (this.ContextMenuStrip == null)
                {
                    textWebBrowser.Document.ContextMenuShowing += (sender, e) => { ; };
                }
            }
        }

        void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            this.ContextMenuStrip.Show(this, this.PointToClient(Cursor.Position));
        }

        public string Html
        {
            get
            {
                
                var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                
                // sample for getting CHECKED states
                if (textWebBrowser.Document.GetElementsByTagName("input").Count > 0)
                {
                    Console.WriteLine(textWebBrowser.Document.GetElementsByTagName("input")[0].GetAttribute("checked"));
                }

                /* this previously returned textWebBrowser.DocumentText, so the following HTML is now omitted:
                   < !DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
                   < HTML >< HEAD >
                   < META content = "text/html; charset=unicode" http - equiv = Content - Type >
                   < META name = GENERATOR content = "MSHTML 11.00.10570.1001" ></ HEAD >
                   < BODY ></ BODY ></ HTML > 
                */ /*
                if (doc != null)
                {
                    return doc.body.innerHTML;
                }
                else
                {
                    return "";
                }
                */
                return textWebBrowser.DocumentText;
            }
            set
            {
                if (textWebBrowser.Document != null)
                {
                    // updating this way avoids an alert box
                    var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                    if (doc != null)
                    {
                        doc.write(value);
                        doc.close();
                    }
                }
            }
        }
        
        public void InsertTextAtCursor(string val)
        {
            _doc.ExecCommand("Paste", false, val);
        }

        private void CheckCommandStateChanges()
        {
            var doc = (IHTMLDocument2)_doc.DomDocument;

            var commands = new List<string>();
            foreach (var button in _customButtons)
            {
                if (button is IHTMLEditorButton)
                {
                    var temp = (IHTMLEditorButton)button;
                    commands.Add(temp.CommandIdentifier);
                }
            }
            //var commands = _customButtons.Select(c => c.CommandIdentifier).Where(c => !string.IsNullOrEmpty(c)); 

            foreach (var command in commands)
            {
                var button = (ToolStripButton)editcontrolsToolStrip.Items[command];

                if (button == null) continue;

                if (doc.queryCommandState(command))
                {
                    if (button.CheckState != CheckState.Checked)
                    {
                        button.Checked = true;
                    }
                }
                else
                {
                    if (button.CheckState == CheckState.Checked)
                    {
                        button.Checked = false;
                    }
                }
            }
        }

        private void HtmlEditor_ContextMenuStripChanged(object sender, System.EventArgs e)
        {
            if (textWebBrowser.Document != null)
            {
                textWebBrowser.Document.ContextMenuShowing += Document_ContextMenuShowing;
            }
        }

        private void textWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // http://stackoverflow.com/questions/18035579/how-to-open-a-link-in-webbrowser-control-in-external-browser
            // terminate current Navigating event; launch a new Process with the target URL to open user's default browser
            if (ReadOnly)
            {
                e.Cancel = true;

                Process.Start(e.Url.ToString());
            }
        }

        public string insertCheckbox(string label = null)
        {
            Random rand = new Random();
            string letters = "qwertyuiopasdfghjklzxcvbnm";
            string identifier = rand.Next(1000000000, int.MaxValue).ToString() +
                letters[rand.Next(letters.Length)];
            InsertTextAtCursor(identifier); // place random int in checkbox's position
                                            // pasting HTML doesn't work
            Console.WriteLine("before pause " + identifier);
            System.Threading.Thread.Sleep(5000);
            string html = this.Html;
            if (label == null)
            {
                // place plain checkbox
                html = html.Replace(identifier,
                    "<input type=\"checkbox\" id=\"" + identifier + "\">");
            }
            else
            {
                // place checkbox and label
                html = html.Replace(identifier,
                    "<input type=\"checkbox\" id=\"" + identifier + "\"> " + label + "<br>");
            }
            
            this.Html = html; // reload

            return identifier;
        }

        public Dictionary<string,string> getCheckedStates()
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            foreach (HtmlElement item in textWebBrowser.Document.GetElementsByTagName("input"))
            {
                output.Add(item.GetAttribute("id"), item.GetAttribute("checked"));
            }
            return output;
        }
    }
}
