namespace JSFW.FunctionSnippet
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelOK = new System.Windows.Forms.Button();
            this.btnDelCancel = new System.Windows.Forms.Button();
            this.btnConvertToString = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnTextAlign = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cboTag = new System.Windows.Forms.ComboBox();
            this.label1 = new JSFW.FunctionSnippet.Controls.Label();
            this.snippetEditControl1 = new JSFW.FunctionSnippet.Controls.SnippetEditControl();
            this.label2 = new JSFW.FunctionSnippet.Controls.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 572);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(93, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDelOK
            // 
            this.btnDelOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelOK.Location = new System.Drawing.Point(12, 12);
            this.btnDelOK.Name = "btnDelOK";
            this.btnDelOK.Size = new System.Drawing.Size(75, 23);
            this.btnDelOK.TabIndex = 1;
            this.btnDelOK.Text = "완료";
            this.btnDelOK.UseVisualStyleBackColor = true;
            this.btnDelOK.Click += new System.EventHandler(this.btnDelOK_Click);
            // 
            // btnDelCancel
            // 
            this.btnDelCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCancel.Location = new System.Drawing.Point(93, 12);
            this.btnDelCancel.Name = "btnDelCancel";
            this.btnDelCancel.Size = new System.Drawing.Size(75, 23);
            this.btnDelCancel.TabIndex = 1;
            this.btnDelCancel.Text = "취소";
            this.btnDelCancel.UseVisualStyleBackColor = true;
            this.btnDelCancel.Click += new System.EventHandler(this.btnDelCancel_Click);
            // 
            // btnConvertToString
            // 
            this.btnConvertToString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertToString.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConvertToString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertToString.ForeColor = System.Drawing.Color.White;
            this.btnConvertToString.Location = new System.Drawing.Point(1168, 13);
            this.btnConvertToString.Name = "btnConvertToString";
            this.btnConvertToString.Size = new System.Drawing.Size(90, 22);
            this.btnConvertToString.TabIndex = 3;
            this.btnConvertToString.Text = "변환";
            this.btnConvertToString.UseVisualStyleBackColor = false;
            this.btnConvertToString.Click += new System.EventHandler(this.btnConvertToString_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(240, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(199, 21);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(633, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(52, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "검색";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnTextAlign
            // 
            this.btnTextAlign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTextAlign.Location = new System.Drawing.Point(948, 13);
            this.btnTextAlign.Name = "btnTextAlign";
            this.btnTextAlign.Size = new System.Drawing.Size(73, 23);
            this.btnTextAlign.TabIndex = 5;
            this.btnTextAlign.Text = "줄 맞춤";
            this.btnTextAlign.UseVisualStyleBackColor = true;
            this.btnTextAlign.Click += new System.EventHandler(this.btnTextAlign_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(824, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "코드조각 생성";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboTag
            // 
            this.cboTag.FormattingEnabled = true;
            this.cboTag.Location = new System.Drawing.Point(467, 15);
            this.cboTag.Name = "cboTag";
            this.cboTag.Size = new System.Drawing.Size(160, 20);
            this.cboTag.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(761, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "포커스";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // snippetEditControl1
            // 
            this.snippetEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.snippetEditControl1.Location = new System.Drawing.Point(238, 40);
            this.snippetEditControl1.Name = "snippetEditControl1";
            this.snippetEditControl1.Padding = new System.Windows.Forms.Padding(2);
            this.snippetEditControl1.Size = new System.Drawing.Size(1020, 576);
            this.snippetEditControl1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "or";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 626);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTextAlign);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnConvertToString);
            this.Controls.Add(this.snippetEditControl1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnDelCancel);
            this.Controls.Add(this.btnDelOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "코드 조각관리";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDelOK;
        private System.Windows.Forms.Button btnDelCancel;
        private Controls.SnippetEditControl snippetEditControl1;
        private System.Windows.Forms.Button btnConvertToString;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnTextAlign;
        private System.Windows.Forms.Button button1;
        private Controls.Label label1;
        private System.Windows.Forms.ComboBox cboTag;
        private Controls.Label label2;
    }
}

