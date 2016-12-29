using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using mshtml;
using YARTE.UI.Buttons;

namespace YARTE.UI
{
    public partial class HtmlEditor : UserControl
    {
        private readonly HtmlDocument _doc;
        private readonly IList<IFunctionButton> _customButtons;

        public HtmlEditor()
        {
            InitializeComponent();

            InitializeWebBrowserAsEditor();

            _doc = textWebBrowser.Document;
            _customButtons = new List<IFunctionButton>();

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

            var args = new HTMLEditorButtonArgs();
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
            toolStripButton.Text = toolbarItem.IconTooltip;

            var args = new HTMLEditorButtonArgs();
            args.Document = _doc;
            args.Editor = this;

            IFunctionButton button = toolbarItem;
            toolStripButton.Click += (sender, o) => button.IconClicked(args);

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
                if (textWebBrowser.Document != null)
                {
                    var designMode = value ? "Off" : "On";
                    var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                    if (doc != null) doc.designMode = designMode;
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

        public string InsertTextAtCursor
        {
            set { _doc.ExecCommand("Paste", false, value); }
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
    }
}
