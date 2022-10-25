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
    public partial class ParameterValueItemControl : UserControl
    {
        public event EventHandler DeleteClick = null;

        public string TextValue { get { return label1.Text.Trim(); } }

        public ParameterValueItemControl()
        {
            InitializeComponent();
        }

        public void SetTextValue(string value)
        {
            label1.Text = ( value ?? "" ).Trim();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // 값 삭제. 
            if (DeleteClick != null)
            {
                DeleteClick(this, e);
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e); 
            // 선택!
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.Coral;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;
        }
    }
}
