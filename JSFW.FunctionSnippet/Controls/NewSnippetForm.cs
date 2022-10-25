using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JSFW.FunctionSnippet.Controls
{
    public partial class NewSnippetForm : Form
    {
        public bool IsNew { get; private set; }

        public string SnippetName { get { return txtSnippetName.Text; } protected set { txtSnippetName.Text = value; } }

        public string TagName { get { return txtTag.Text; } protected set { txtTag.Text = value; } }

        public NewSnippetForm(string[] lst )
        {
            InitializeComponent();
            IsNew = true;
            cboTagList.Items.AddRange(lst);
            cboTagList.SelectedIndex = -1;
        }

        public NewSnippetForm(Snippet snippet, string[] lst) : this(lst)
        {
            IsNew = false;
            if (snippet != null)
            {
                SnippetName = snippet.Name;
                TagName = "" + snippet.Tag;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtSnippetName.Focus();
        }
 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsNew && string.IsNullOrEmpty( SnippetName.Trim() ) )
            {
                MessageBox.Show("이름을 설정하세요.");
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        public bool IsDataModified = false; 

        private void txtSnippetName_TextChanged(object sender, EventArgs e)
        {
            IsDataModified = true;
        }

        private void txtSnippetName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 선택된 것은... 
            if (string.IsNullOrEmpty(cboTagList.Text.Trim()) == false)
            {
                txtTag.Text = "" + cboTagList.Text;
            }
        }
    }
}
