using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JSFW.FunctionSnippet.Controls
{
    public partial class ParameterControl : UserControl
    { 
        PopupControl.Popup ParameterTextArrayViewPopup;
        ParameterTextViewControl TextViewControl;

        public event EventHandler<ParameterEventArgs> AddEvent = null;

        public event EventHandler<ParameterEventArgs> DeleteEvent = null;

        public bool IsNew { get; set; }
        public string SnippetAsName { get { return string.Format("${0}$", lbName.Text);} }
        public string SnippetAsText { get { return txtText.Text; } } 
        public string SnippetByName { get { return lbName.Text; } }
        public string[] ParameterValues
        {
            get
            {
                if (TextViewControl == null && string.IsNullOrEmpty(SnippetAsText.Trim()) == false) return new string[] { SnippetAsText };
                return TextViewControl.GetParameterValues(SnippetAsText);
            }
        }

        public ParameterControl()
        {
            InitializeComponent();
            ParameterTextArrayViewPopup = new PopupControl.Popup(TextViewControl = new ParameterTextViewControl());
            ParameterTextArrayViewPopup.AutoClose = true;
            ParameterTextArrayViewPopup.Opened += ParameterTextArrayViewPopup_Opened;
            TextViewControl.ValueSelected += TextViewControl_ValueSelected;
            IsNew = false;
            this.Disposed += ParameterControl_Disposed;
        }

        private void ParameterTextArrayViewPopup_Opened(object sender, EventArgs e)
        {
            Action act = new Action(() => {
                System.Threading.Thread.Sleep(200);
                TextViewControl.DoAsync(c =>
                {
                    ParameterTextArrayViewPopup.Height = TextViewControl.AdjustHeight();                    
                });                
            });
            act.BeginInvoke(ir => act.EndInvoke(ir), act);
        }
         
        private void TextViewControl_ValueSelected(string value)
        {
            txtText.Text = value;
        }

        private void ParameterControl_Disposed(object sender, EventArgs e)
        {
            using (ParameterTextArrayViewPopup)
            {
                if(ParameterTextArrayViewPopup != null)
                    ParameterTextArrayViewPopup.Opened -= ParameterTextArrayViewPopup_Opened;
                using (TextViewControl) {
                    if( TextViewControl != null)
                        TextViewControl.ValueSelected -= TextViewControl_ValueSelected;
                }
            }
            ParameterTextArrayViewPopup = null;
            TextViewControl = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (IsNew)
            {
                btnAdd.BringToFront();
            }
            else
            {
                btnDel.BringToFront();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           // if (MessageBox.Show("추가?", "Q", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            if (string.IsNullOrEmpty(lbName.Text.Trim()))
            {
                MessageBox.Show("이름이 필요합니다.");
                txtText.Focus();
                return;
            }

            if (AddEvent != null)
            {
                AddEvent(this, new ParameterEventArgs() { Name = lbName.Text });
                txtText.Text = ""; //초기화.
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbName.Text.Trim())) return;

            if (MessageBox.Show("삭제?", "Q", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            if (DeleteEvent != null)
            {
                DeleteEvent(this, new ParameterEventArgs() { Name = lbName.Text }); 
            }
        }

        internal void SetParameter(SnippetParameter p)
        {
            txtText.Text = p.Value;
            lbName.Text = p.Name;

            if (TextViewControl != null)
            {
                TextViewControl.SetTextViews(p);
            }
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (IsNew)
            {
                lbName.Text = txtText.Text;
            }
        }

        bool isMouseDown = false; 
        Point pt;
        private void lbName_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = false; 
            if (e.Button == MouseButtons.Left && !IsNew)
            {
                isMouseDown = true;
            }
            pt = e.Location;
        }

        private void lbName_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int x = e.Location.X - pt.X;
                int y = e.Location.Y - pt.Y;
                int z = (int)Math.Sqrt(Math.Pow((double)Math.Abs(x), 2d) + Math.Pow((double)Math.Abs(y), 2d));

                if (4 < z)
                {
                    if (isMouseDown)
                    {
                        try
                        {
                            DoDragDrop(SnippetAsName, DragDropEffects.Copy);
                            Clipboard.SetText(SnippetAsName);
                            isMouseDown = false;
                        }
                        finally
                        {
                        }
                    } 
                }
            }
        }

        private void lbName_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && IsNew)
            {
                btnAdd.PerformClick();
            }
        }

        private void lbName_MouseHover(object sender, EventArgs e)
        {
            if (TextViewControl.HasParameterValues)
            {
                ParameterTextArrayViewPopup.Show(this); 
            }
        }
         
    }

    public class ParameterEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}
