using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JSFW.FunctionSnippet.Controls;

namespace JSFW.FunctionSnippet
{
    public partial class MainForm : Form
    {
        SnippetManager sManager = null;

        //윈도우 다른 창으로 커서 이동 x
        //https://kdsoft-zeros.tistory.com/139
        // 포커스 설정 x
        long WS_NOACTIVE = 0x8000000L;
         

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | (int)WS_NOACTIVE; 
                return cp;
            }
        }


        /// <summary>
        /// The instance of the <see cref="IInputMessageDispatcher"/> to use for dispatching <see cref="INPUT"/> messages.
        /// </summary>
        private readonly IInputMessageDispatcher _messageDispatcher;


        public MainForm()
        {
            InitializeComponent();
            _messageDispatcher = new WindowsInputMessageDispatcher();
            this.Disposed += MainForm_Disposed;
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            SelectedSnipptControl = null;
            sManager = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            sManager = SnippetManager.Load() ?? new SnippetManager(); 
            DataBind(); 
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            snippetEditControl1.Commit();
            sManager.Save();
            base.OnFormClosing(e);
        }

        private void DataBind()
        { 
            try
            {
                flowLayoutPanel1.SuspendLayout();
                DataClear();

                if (sManager != null)
                { 
                    foreach (var sp in sManager.Snippets.OrderBy(s => !s.IsFavorite).ThenBy(s => s.Name))
                    {
                        SnippetControl spc = new SnippetControl();
                        spc.SetSnippet(sp);
                        flowLayoutPanel1.Controls.Add(spc);
                        spc.ItemDbClick += MainForm_ItemDbClick;
                        spc.ItemSelected += MainForm_ItemSelected;
                        spc.ChangeFavorite += Spc_ChangeFavorite;                        
                    }

                    BindTagCombo();

                    if (0 < flowLayoutPanel1.Controls.Count) SetSnippetControl(flowLayoutPanel1.Controls[0] as SnippetControl);
                }

                Finding();
            }
            finally {
                flowLayoutPanel1.ResumeLayout();
            }
        }

        private void BindTagCombo()
        {
            cboTag.Items.Clear(); 
            List<string> cboTagList = new List<string>();
            foreach (SnippetControl snc in flowLayoutPanel1.Controls)
            {
                string tmp = ("" + snc.Snippet.Tag).Trim();
                if (string.IsNullOrEmpty(tmp)) { continue; }
                if (!cboTagList.Contains(tmp))
                {
                    cboTagList.Add(tmp);
                }
            }

            cboTag.Items.Add("");
            foreach (var tag in cboTagList.OrderBy( o => o))
            {
                cboTag.Items.Add(tag);
            }
            cboTag.SelectedIndex = 0;
        }

        private void Spc_ChangeFavorite(object sender, EventArgs e)
        {
            // 재정렬! 
            Action act = new Action(() =>
            {
                System.Threading.Thread.Sleep(200);
                this.DoAsync(c => DataBind());
            });
            act.BeginInvoke(ir => act.EndInvoke(ir), act);
        }

        private void DataClear()
        {
            SetSnippetControl(null);

            cboTag.Items.Clear();

            for (int loop = flowLayoutPanel1.Controls.Count - 1; loop >= 0; loop--)
            {
                using (flowLayoutPanel1.Controls[loop])
                {
                    SnippetControl spc = flowLayoutPanel1.Controls[loop] as SnippetControl;
                    if (spc != null)
                    {
                        spc.ItemDbClick -= MainForm_ItemDbClick;
                        spc.ItemSelected -= MainForm_ItemSelected;
                        spc.ChangeFavorite -= Spc_ChangeFavorite;
                        flowLayoutPanel1.Controls.Remove(spc);
                        spc = null;
                    }
                }
            }
            flowLayoutPanel1.Controls.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> arr = new List<string>();
            foreach (var item in cboTag.Items)
            {
                if (string.IsNullOrEmpty("" + item)) continue;

                arr.Add("" + item);
            }

            using (NewSnippetForm nsf = new NewSnippetForm(arr.ToArray()))
            {
                if (nsf.ShowDialog() == DialogResult.OK)
                {
                    Snippet sp = new Snippet() { Name = nsf.SnippetName, Tag = nsf.TagName };
                    sManager.Add(sp);
                    SnippetControl spc = new SnippetControl();
                    spc.SetSnippet(sp);
                    flowLayoutPanel1.Controls.Add(spc);
                    spc.ItemDbClick += MainForm_ItemDbClick;
                    spc.ItemSelected += MainForm_ItemSelected;
                    spc.ChangeFavorite += Spc_ChangeFavorite;
                    SetSnippetControl(spc);

                    BindTagCombo();
                }
            } 
        }


        SnippetControl SelectedSnipptControl { get; set; }
        private void SetSnippetControl(SnippetControl spc)
        {
            if (SelectedSnipptControl != null) {
                SelectedSnipptControl.BackColor = this.BackColor;
                SelectedSnipptControl.ForeColor = this.ForeColor;
                SaveSnippetItem(SelectedSnipptControl);
            }

            SelectedSnipptControl = spc;

            if (SelectedSnipptControl != null)
            {
                SelectedSnipptControl.BackColor = Color.DeepSkyBlue;
                SelectedSnipptControl.ForeColor = Color.White;
                SnippetEditContent(SelectedSnipptControl); 
            } 
        }

        private void SaveSnippetItem(SnippetControl spc)
        {
            // 에디트 컨트롤 ... 커밋.
            snippetEditControl1.Commit();
            sManager.Save();
        }

        private void SnippetEditContent(SnippetControl spc)
        {
            // 에디트 컨트롤 .... 바인딩.
            snippetEditControl1.SetSnippet( sManager, spc.Snippet);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (SnippetControl item in flowLayoutPanel1.Controls)
            {
                item.ShowDeleteCheckBox();
            }
            btnDelOK.BringToFront();
            btnDelCancel.BringToFront();
        }

        private void btnDelCancel_Click(object sender, EventArgs e)
        {
            foreach (SnippetControl item in flowLayoutPanel1.Controls)
            {
                item.HideDeleteCheckBox();
            }
            btnDelOK.SendToBack();
            btnDelCancel.SendToBack();
        }

        private void btnDelOK_Click(object sender, EventArgs e)
        {
            // 삭제 처리!!
            snippetEditControl1.Commit();
            snippetEditControl1.SetSnippet(sManager, null);

            if (MessageBox.Show("삭제?", "Q", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            List<SnippetControl> dels = new List<SnippetControl>();
            foreach (SnippetControl item in flowLayoutPanel1.Controls)
            {
                if (item.IsSelected) dels.Add(item);
            }

            for (int loop = dels.Count - 1; loop >= 0; loop--)
            {
                using (dels[loop])
                {
                    dels[loop].ItemDbClick -= MainForm_ItemDbClick;
                    dels[loop].ItemSelected -= MainForm_ItemSelected;
                    dels[loop].ChangeFavorite -= Spc_ChangeFavorite;
                    sManager.Remove(dels[loop].Snippet);
                    flowLayoutPanel1.Controls.Remove(dels[loop]);
                }
            }

            sManager.Save();

            BindTagCombo();

            foreach (SnippetControl item in flowLayoutPanel1.Controls)
            {
                item.HideDeleteCheckBox();
            }
            btnDelOK.SendToBack();
            btnDelCancel.SendToBack();
        }

        private void MainForm_ItemSelected(object sender, ItemSelectedEventArgs<SnippetControl> e)
        {
            // 선택!
            SetSnippetControl(e.Item);
        }

        private void MainForm_ItemDbClick(object sender, ItemSelectedEventArgs<SnippetControl> e)
        {
            //  이름 고치기... 상세?
            List<string> arr = new List<string>();
            foreach (var item in cboTag.Items)
            {
                if (string.IsNullOrEmpty("" + item)) continue;

                arr.Add("" + item); 
            }

            using (NewSnippetForm nsf = new NewSnippetForm(e.Item.Snippet, arr.ToArray() ))
            {
                if (nsf.ShowDialog() == DialogResult.OK && nsf.IsDataModified)
                {
                    e.Item.Snippet.Name = nsf.SnippetName;
                    e.Item.Snippet.Tag = nsf.TagName;
                    e.Item.SetSnippet(e.Item.Snippet);
                    SetSnippetControl(e.Item);
                    BindTagCombo();
                }
            }
        }

        private void btnConvertToString_Click(object sender, EventArgs e)
        {
            // 소스 변환.
            string source = snippetEditControl1.ConvertToSource();
            if (!string.IsNullOrEmpty(source.Trim()))
            {
                Clipboard.SetText(source);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind.PerformClick();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // 검색
            SetSnippetControl(null); 
            snippetEditControl1.SetSnippet(sManager, null);
            Finding();
            txtSearch.Focus();
        }

        private void Finding()
        {
            UnFinding();

            string searchText = txtSearch.Text.Trim().ToUpper();
            string tag = (cboTag.Text).Trim();
             
            foreach (SnippetControl item in flowLayoutPanel1.Controls)
            { 
                if (string.IsNullOrEmpty(searchText) && string.IsNullOrEmpty(tag))
                {
                    item.Visible = true;
                }
                else if (string.IsNullOrEmpty(searchText) && !string.IsNullOrEmpty(tag))
                {
                    item.Visible = ("" + item.Snippet.Tag) == tag;
                }
                else
                {
                    item.Visible = item.Snippet.Name.ToUpper().Contains(searchText) || ("" + item.Snippet.Tag) == tag;
                }

                if (item.Visible && SelectedSnipptControl == null)
                {
                    SetSnippetControl(item);
                }
            }
        }

        private void UnFinding()
        {
            SetSnippetControl(null);
            foreach (SnippetControl item in flowLayoutPanel1.Controls)
            {
                item.Visible = true;
            }
        }
         
        private void btnTextAlign_Click(object sender, EventArgs e)
        {
            // 줄맞춤.
            snippetEditControl1.TextLinesClean();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 코드 조각 생성
            if (SelectedSnipptControl != null)
            {
                string xml = SelectedSnipptControl.Snippet.CreateSnippetXml();

                string usrProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                // C:\Users\aseuk\Documents\Visual Studio 2019\Code Snippets\Visual Basic\My Code Snippets
                string dir = string.Format(@"{0}\Documents\Visual Studio 2019\Code Snippets\Visual C#\My Code Snippets\", usrProfile);
                //object usrName = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

                string fileName = string.Format(@"{0}{1}.snippet", dir, SelectedSnipptControl.Snippet.Name);
                if (Directory.Exists(dir))
                {
                    //if (File.Exists(fileName))
                    //    File.Delete(fileName); 
                    File.WriteAllText(fileName, xml, Encoding.UTF8);
                }
            }
        }


        bool isMouseDown = false;
        Point pt;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = e.Button == MouseButtons.Left;
            pt = e.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
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
                            snippetEditControl1.ClearSelectEnd();
                            DoDragDrop("$select$ $end$", DragDropEffects.Copy);
                        }
                        finally
                        {
                            isMouseDown = false;
                        }
                    }
                }
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void btnOtherPGM_Send_Click(object sender, EventArgs e)
        {
            btnConvertToString.PerformClick(); // 클립보드 복사.

            string source = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(source))
            {
                TextEntry(source.Replace("\r", ""));
            }
        }
    }

    public class SnippetManager  
    {
        public List<Snippet> Snippets { get; set; }
      
        public SnippetManager()
        {
            Snippets = new List<Snippet>();
        }

        public void Add(Snippet unit)
        {
            Snippets.Add(unit); 
            Save();
        }

        public static void AllClear()
        {
            // 모두 지워.
            if (Directory.Exists(StaticConst.JSFW_SNIPPET_DIR))
            {
                RemoveDirectoryAndFiles(StaticConst.JSFW_SNIPPET_DIR);

                Directory.CreateDirectory(StaticConst.JSFW_SNIPPET_DIR);
            }
            else
            {
                Directory.CreateDirectory(StaticConst.JSFW_SNIPPET_DIR);
            }
        }

        private static void RemoveDirectoryAndFiles(string dir)
        {
            string[] files = Directory.GetFiles(dir);

            foreach (var file in files)
            {
                File.Delete(file);
            }

            string[] dirs = Directory.GetDirectories(dir);
            foreach (var item in dirs)
            {
                RemoveDirectoryAndFiles(item);
            }
            Directory.Delete(dir);
        }

        public void Remove(Snippet unit)
        {
            Snippets.Remove(unit); 
            Save();
        }

        internal static readonly string ConfigFileName = @"SnippetManager.xml";

        public void Save()
        {
            // 프로젝트 목록 저장하기!
            string dir = GetFolderName();

            if (Directory.Exists(dir) == false) Directory.CreateDirectory(dir);

            string fileName = dir + ConfigFileName;
            // 프로젝트 목록 저장.
            string xml = this.Serialize();
            if (System.IO.File.Exists(fileName)) System.IO.File.Delete(fileName);
            System.IO.File.AppendAllText(fileName, xml);
        }

        public static SnippetManager Load()
        {
            string dir = GetFolderName();
            string fileName = dir + ConfigFileName;

            // 프로젝트 목록 저장.
            string xml = "";
            if (System.IO.File.Exists(fileName))
            {
                xml = File.ReadAllText(fileName);
                return xml.DeSerialize<SnippetManager>();
            }
            return null;
        }

        public static string GetFolderName()
        {
            return StaticConst.JSFW_SNIPPET_DIR;
        }

    }
     
    internal class StaticConst
    {
        /// <summary>
        /// C:\JSFW\
        /// </summary>
        public static readonly string JSFW_DIR = @"C:\JSFW\";
         
        /// <summary>
        /// JSFW_DIR + @"NPT\"
        /// </summary>
        public static readonly string JSFW_SNIPPET_DIR = JSFW_DIR + @"SNIPPET\"; 
    }

    public class Snippet
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public string Content { get; set; } = "";

        public List<SnippetParameter> Parameters { get; set; }

        public Snippet()
        {
            Parameters = new List<SnippetParameter>();
            ID = Guid.NewGuid().ToString("N");
        }

        public string Tag { get; set; }

        /// <summary>
        /// 즐겨찾기.
        /// </summary>
        public bool IsFavorite { get; set; }

        internal string CreateSnippetXml()
        { 
            string xmlbase = @"<CodeSnippet Format=""1.1.0"" xmlns=""http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet"">
    <Header>
        <Title>" + Name + @"</Title>
        <Author>JSFW</Author>
        <Shortcut>"+Name+ @"</Shortcut>
        <Description>Code snippet for """ + Name + @"""</Description>
        <SnippetTypes>
            <SnippetType>Expansion</SnippetType>
        </SnippetTypes>
    </Header>
    <Snippet>
        <Declarations>
            " + GetLiteralString() + @" 
        </Declarations>
        <Code Language=""JavaScript"">
            <![CDATA["+Content+@"]]>
        </Code>
    </Snippet>
</CodeSnippet>";

            return xmlbase;
        }

        private string GetLiteralString()
        {
            string literal = "";
            foreach (var prms in Parameters)
            {
                literal += string.Format(@"
            <Literal>
                <ID>{0}</ID>
                <ToolTip>{0}</ToolTip>
                <Default>{1}</Default>
            </Literal>
", prms.Name, prms.Value );
            }

            return literal;
        }
    }

    public class SnippetParameter
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public List<string> Values { get; set; }

        public SnippetParameter()
        {
            Type = "Nomal";
            Values = new List<string>();
        } 
    }



}
