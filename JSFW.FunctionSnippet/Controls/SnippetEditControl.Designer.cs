namespace JSFW.FunctionSnippet.Controls
{
    partial class SnippetEditControl
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
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.parameterControl1 = new JSFW.FunctionSnippet.Controls.ParameterControl();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.pnlParameters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParameters
            // 
            this.pnlParameters.BackColor = System.Drawing.Color.White;
            this.pnlParameters.Controls.Add(this.flowLayoutPanel1);
            this.pnlParameters.Controls.Add(this.panel1);
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlParameters.Location = new System.Drawing.Point(820, 2);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(236, 499);
            this.pnlParameters.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(236, 476);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.parameterControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 23);
            this.panel1.TabIndex = 0;
            // 
            // parameterControl1
            // 
            this.parameterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterControl1.IsNew = true;
            this.parameterControl1.Location = new System.Drawing.Point(0, 0);
            this.parameterControl1.Name = "parameterControl1";
            this.parameterControl1.Padding = new System.Windows.Forms.Padding(1, 1, 4, 1);
            this.parameterControl1.Size = new System.Drawing.Size(236, 23);
            this.parameterControl1.TabIndex = 0;
            this.parameterControl1.AddEvent += new System.EventHandler<JSFW.FunctionSnippet.Controls.ParameterEventArgs>(this.parameterControl1_AddEvent);
            // 
            // elementHost1
            // 
            this.elementHost1.AllowDrop = true;
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(2, 2);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(818, 499);
            this.elementHost1.TabIndex = 2;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // SnippetEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.pnlParameters);
            this.Name = "SnippetEditControl";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(1058, 503);
            this.pnlParameters.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private ParameterControl parameterControl1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}
