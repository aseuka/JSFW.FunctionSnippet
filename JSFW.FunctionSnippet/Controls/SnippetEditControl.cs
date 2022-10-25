using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit.Highlighting;

namespace JSFW.FunctionSnippet.Controls
{
    public partial class SnippetEditControl : UserControl
    {
        readonly static string FontFamilyFilePath = Application.StartupPath + @"\Font\UbuntuMono-B.ttf";

        ICSharpCode.AvalonEdit.TextEditor txtContent = new ICSharpCode.AvalonEdit.TextEditor()
        {
            SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#"), 
            FontSize = 14,
            AllowDrop = true,
        };
          
        SnippetManager sManager { get; set; }

        Snippet Snippet { get; set; }

        public SnippetEditControl()
        {
            InitializeComponent();

            try
            {
                txtContent.FontFamily = System.Windows.Media.Fonts.GetFontFamilies(FontFamilyFilePath).ElementAt(0);
            }
            catch { }

            txtContent.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(txtContent.Options);
            txtContent.ShowLineNumbers = true;
            elementHost1.Child = txtContent;


            this.Disposed += SnippetEditControl_Disposed;
        }

        private void SnippetEditControl_Disposed(object sender, EventArgs e)
        {
            txtContent = null;
            sManager = null;
            Snippet = null;
        }

        private void txtContent_Leave(object sender, EventArgs e)
        {
            // 저장 처리. 
            Commit();
            if (sManager != null)
            {
                sManager.Save();
            }
        }

        internal void SetSnippet(SnippetManager smng, Snippet sp)
        {
            sManager = smng;
            Snippet = sp;
            DataBind();
        }

        private void DataBind()
        {
            DataClear();
            if (Snippet != null)
            {
                Enabled = true;
                txtContent.Text = Snippet.Content.Replace("\r", "").Replace("\n", Environment.NewLine);
             
                foreach (var p in Snippet.Parameters)
                {
                    ParameterControl pc = new ParameterControl();
                    pc.SetParameter(p);
                    flowLayoutPanel1.Controls.Add(pc);
                    pc.DeleteEvent += Pc_DeleteEvent;
                }
            }
            else
            {
                Enabled = false;
            }
        }

        private void DataClear()
        {
            txtContent.Clear();

            for (int loop = flowLayoutPanel1.Controls.Count - 1; loop >= 0; loop--)
            {
                using (flowLayoutPanel1.Controls[loop])
                {
                    ParameterControl pc = flowLayoutPanel1.Controls[loop] as ParameterControl;
                    if (pc != null)
                    {
                        pc.DeleteEvent -= Pc_DeleteEvent;
                    }
                    flowLayoutPanel1.Controls.Remove(pc);
                }
            }
            flowLayoutPanel1.Controls.Clear();
        }

        private void Pc_DeleteEvent(object sender, ParameterEventArgs e)
        {
            ParameterControl pc = sender as ParameterControl;
            using (pc)
            {
                if (pc != null)
                {
                    pc.DeleteEvent -= Pc_DeleteEvent;
                    flowLayoutPanel1.Controls.Remove(pc);
                    if (Snippet.Parameters.Any(p => p.Name == e.Name))
                    {
                        SnippetParameter sp = Snippet.Parameters.Find(p => p.Name == e.Name);
                        Snippet.Parameters.Remove(sp);
                    }
                    sManager.Save();
                }
            }
        }

        internal void Commit()
        {
            if (Snippet != null)
            {
                Snippet.Content = txtContent.Text;
                Snippet.Parameters.Clear();
                foreach (ParameterControl prms in flowLayoutPanel1.Controls)
                {
                    var sp = new SnippetParameter() { Name = prms.SnippetByName, Value = prms.SnippetAsText };
                    sp.Values.AddRange(prms.ParameterValues);
                    Snippet.Parameters.Add(sp);
                    prms.SetParameter(sp); // 갱신.
                }
            }
        }

        internal string ConvertToSource()
        {
            Commit();
            sManager.Save();
            string source = "";
            // 소스 변환. ( 파라미터로 변환 처리. )
            if (string.IsNullOrEmpty(txtContent.Text.Trim()) == false)
            {
                source = txtContent.Text;
                for (int loop = 0; loop < flowLayoutPanel1.Controls.Count; loop++)
                {
                    ParameterControl pc = flowLayoutPanel1.Controls[loop] as ParameterControl;
                    if (pc != null)
                    {
                        source = source.Replace(pc.SnippetAsName, pc.SnippetAsText);
                    }
                }

            }
            return source;
        }

        private void parameterControl1_AddEvent(object sender, ParameterEventArgs e)
        {
            if (Snippet.Parameters.Any(a => a.Name == e.Name))
            {
                MessageBox.Show("이미 존재하는 이름입니다.");
                return;
            }
            var p = new SnippetParameter() { Name = e.Name, Value = e.Name };
            ParameterControl pc = new ParameterControl();
            pc.SetParameter(p);
            flowLayoutPanel1.Controls.Add(pc);
            pc.DeleteEvent += Pc_DeleteEvent;
            Snippet.Parameters.Add(p);
            sManager.Save();
        }

        //private void txtContent_DragDrop(object sender, DragEventArgs e)
        //{
        //    if (e.AllowedEffect == DragDropEffects.Link)
        //    {
        //        string pName = "" + e.Data.GetData(typeof(string));
        //        //int position = txtContent.GetCharFromPosition(new Point(e.X, e.Y));
        //        txtContent.Paste(pName);
        //        //txtContent.Text = pName;
        //    }
        //}

        //private void txtContent_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.AllowedEffect == DragDropEffects.Link)
        //    {
        //        e.Effect = e.AllowedEffect;
        //        txtContent.Focus();
        //    }
        //    else
        //    {
        //        e.Effect = DragDropEffects.None;
        //    }
        //}

        //private void txtContent_DragOver(object sender, DragEventArgs e)
        //{
        //    if (e.AllowedEffect == DragDropEffects.Link)
        //    {
        //        int position = txtContent.GetCharIndexFromPosition(txtContent.PointToClient(MousePosition));
        //        //txtContent.Select(position, 0);
        //        txtContent.SelectionLength = 0;
        //        txtContent.SelectionStart = position;                
        //    }
        //}

        internal void TextLinesClean()
        {
            int prefixMinSpaceCount = int.MaxValue;
            int prefixSpaceCount = 0;

            string txt = txtContent.Document.Text;

            for (int line = 0; line < txtContent.LineCount; line++)
            {
                var lineInfo = txtContent.Document.Lines[line];
                string lineText = txtContent.Document.GetText(lineInfo.Offset, lineInfo.Length);
                lineText = lineText.Replace("\t", "    ");

                if (string.IsNullOrEmpty(lineText)) continue;

                for (int charIndex = 0; charIndex < lineText.Length; charIndex++)
                {
                    if (' ' != lineText[charIndex])
                    {
                        if (prefixSpaceCount < charIndex)
                        {
                            prefixSpaceCount = charIndex;
                        }
                        if (charIndex < prefixMinSpaceCount)
                        {
                            prefixMinSpaceCount = charIndex;
                        }
                        break;
                    }
                }

            }


            List<string> text = new List<string>();
            for (int line = 0; line < txtContent.LineCount; line++)
            {
                var lineInfo = txtContent.Document.Lines[line];
                string lineText = txtContent.Document.GetText(lineInfo.Offset, lineInfo.Length);
                lineText = lineText.Replace("\t", "    ");

                if (prefixMinSpaceCount <= lineText.Length)
                {
                    text.Add(lineText.Substring(prefixMinSpaceCount));
                }
                else
                {
                    text.Add(lineText);
                }
            }
            txtContent.Text = string.Join(Environment.NewLine, text.ToArray());

        }

        internal void ClearSelectEnd()
        {
            txtContent.Text = txtContent.Text.Replace("$select$", "").Replace("$end$", "");
        }

        //internal void TextLinesClean()
        //{
        //    // 텍스트의 탭위치 정리
        //    int prefixMinSpaceCount = int.MaxValue;
        //    int prefixSpaceCount = 0;
        //    for (int line = 0; line < txtContent.Lines.Count; line++)
        //    { 
        //        if (string.IsNullOrEmpty(txtContent.Lines[line].Trim())) continue;

        //        for (int charIndex = 0; charIndex < txtContent.Document.Lines[ line ].Length; charIndex++)
        //        {
        //            if (' ' != txtContent.Lines[line][charIndex])
        //            {
        //                if (prefixSpaceCount < charIndex)
        //                {
        //                    prefixSpaceCount = charIndex;
        //                } 
        //                if (charIndex < prefixMinSpaceCount)
        //                {
        //                    prefixMinSpaceCount = charIndex; 
        //                } 
        //                break;
        //            }
        //        }
        //    }

        //    List<string> text = new List<string>();
        //    for (int line = 0; line < txtContent.Lines.Length; line++)
        //    {
        //        if (prefixMinSpaceCount <= txtContent.Lines[line].Length)
        //        {
        //            text.Add(txtContent.Lines[line].Substring(prefixMinSpaceCount));
        //        }
        //        else
        //        {
        //            text.Add(txtContent.Lines[line]);
        //        }
        //    }
        //    txtContent.Text = string.Join(Environment.NewLine, text.ToArray());
        //}

        //private void txtContent_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.A)
        //    {
        //        txtContent.SelectAll();
        //    }
        //    else if (e.KeyCode == Keys.Tab)
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void txtContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    if (e.Shift && e.KeyCode == Keys.Tab)
        //    {
        //        // 거꾸로... 탭을 뺀다.
        //        if (0 == txtContent.SelectionLength)
        //        {
        //            // 앞에서 공백을 4개를 뺀다. 
        //            txtContent.Select(txtContent.SelectionStart, -4);
        //            if (txtContent.SelectedText == "    ") txtContent.SelectedText = "";
        //            else txtContent.SelectionLength = 0;
        //        }
        //        else
        //        {
        //            string text = txtContent.SelectedText;
        //            int st = txtContent.SelectionStart;
        //            int stOffset = 0;

        //            txtContent.SelectedText = "";

        //            txtContent.Select(txtContent.SelectionStart, -4);

        //            if (txtContent.SelectedText == "    ")
        //            {
        //                stOffset = -4;
        //                txtContent.SelectedText = "";
        //            }
        //            else
        //            {
        //                txtContent.SelectionLength = 0;
        //                txtContent.SelectionStart += 4; 
        //            }
        //            string[] lines = text.Replace("\r", "").Split('\n');
        //            for (int line = 0; line < lines.Length; line++)
        //            {
        //                if (lines[line].StartsWith("    "))
        //                {
        //                    lines[line] = lines[line].Substring("    ".Length);
        //                }
        //            }
        //            string copyText = string.Join(Environment.NewLine, lines); 
        //            txtContent.Paste(copyText);
        //            txtContent.Select(st + stOffset, copyText.Length);
        //            txtContent.HideSelection = false;
        //        }
        //    }
        //    else if (e.KeyCode == Keys.Tab)
        //    {
        //        if (0 == txtContent.SelectionLength)
        //        {
        //            txtContent.Paste("    ");
        //        }
        //        else
        //        {
        //            string text = txtContent.SelectedText;
        //            string[] lines = text.Replace("\r", "").Split('\n');
        //            for (int line = 0; line < lines.Length; line++)
        //            {
        //                lines[line] = "    " + lines[line];
        //            }
        //            string copyText = string.Join(Environment.NewLine, lines);
        //            int st = txtContent.SelectionStart;
        //            txtContent.Paste(copyText); 
        //            txtContent.Select(st + 4, copyText.Length - 4);
        //            txtContent.HideSelection = false;
        //        }  
        //    }

        //}

        //private void txtContent_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\t')
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
