namespace JSFW.FunctionSnippet.Controls
{
    partial class SnippetControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.lbSnippetName = new System.Windows.Forms.Label();
            this.chkFavorite = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkSelect
            // 
            this.chkSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSelect.Location = new System.Drawing.Point(0, 0);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkSelect.Size = new System.Drawing.Size(22, 25);
            this.chkSelect.TabIndex = 0;
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // lbSnippetName
            // 
            this.lbSnippetName.AutoEllipsis = true;
            this.lbSnippetName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSnippetName.Location = new System.Drawing.Point(22, 0);
            this.lbSnippetName.Name = "lbSnippetName";
            this.lbSnippetName.Size = new System.Drawing.Size(164, 25);
            this.lbSnippetName.TabIndex = 1;
            this.lbSnippetName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSnippetName.Click += new System.EventHandler(this.lbSnippetName_Click);
            this.lbSnippetName.DoubleClick += new System.EventHandler(this.lbSnippetName_DoubleClick);
            // 
            // chkFavorite
            // 
            this.chkFavorite.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFavorite.BackColor = System.Drawing.Color.Transparent;
            this.chkFavorite.BackgroundImage = global::JSFW.FunctionSnippet.Properties.Resources.Star_Off;
            this.chkFavorite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkFavorite.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkFavorite.FlatAppearance.BorderSize = 0;
            this.chkFavorite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.chkFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFavorite.ForeColor = System.Drawing.Color.Transparent;
            this.chkFavorite.Location = new System.Drawing.Point(186, 0);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(25, 25);
            this.chkFavorite.TabIndex = 2;
            this.chkFavorite.UseVisualStyleBackColor = false;
            this.chkFavorite.CheckedChanged += new System.EventHandler(this.chkFavorite_CheckedChanged);
            // 
            // SnippetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbSnippetName);
            this.Controls.Add(this.chkFavorite);
            this.Controls.Add(this.chkSelect);
            this.Name = "SnippetControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.Size = new System.Drawing.Size(212, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.Label lbSnippetName;
        private System.Windows.Forms.CheckBox chkFavorite;
    }
}
