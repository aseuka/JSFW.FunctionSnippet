namespace JSFW.FunctionSnippet.Controls
{
    partial class NewSnippetForm
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
            this.label1 = new JSFW.FunctionSnippet.Controls.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSnippetName = new System.Windows.Forms.TextBox();
            this.label2 = new JSFW.FunctionSnippet.Controls.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.cboTagList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "이름";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(199, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSnippetName
            // 
            this.txtSnippetName.Location = new System.Drawing.Point(97, 23);
            this.txtSnippetName.Name = "txtSnippetName";
            this.txtSnippetName.Size = new System.Drawing.Size(270, 21);
            this.txtSnippetName.TabIndex = 0;
            this.txtSnippetName.TextChanged += new System.EventHandler(this.txtSnippetName_TextChanged);
            this.txtSnippetName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSnippetName_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tag";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(97, 50);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(133, 21);
            this.txtTag.TabIndex = 0;
            this.txtTag.TextChanged += new System.EventHandler(this.txtSnippetName_TextChanged);
            this.txtTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSnippetName_KeyDown);
            // 
            // cboTagList
            // 
            this.cboTagList.FormattingEnabled = true;
            this.cboTagList.Location = new System.Drawing.Point(236, 51);
            this.cboTagList.Name = "cboTagList";
            this.cboTagList.Size = new System.Drawing.Size(131, 20);
            this.cboTagList.TabIndex = 3;
            this.cboTagList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // NewSnippetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 127);
            this.Controls.Add(this.cboTagList);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.txtSnippetName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewSnippetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewSnippetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSnippetName;
        private Label label2;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.ComboBox cboTagList;
    }
}