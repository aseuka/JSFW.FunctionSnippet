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
    public partial class SnippetControl : UserControl
    { 
        public event EventHandler<ItemSelectedEventArgs<SnippetControl>> ItemSelected = null;
        public event EventHandler<ItemSelectedEventArgs<SnippetControl>> ItemDbClick = null;

        public event EventHandler ChangeFavorite = null;
        
        public Snippet Snippet { get; set; }

        public SnippetControl()
        {
            InitializeComponent();
            this.Disposed += SnippetControl_Disposed;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e); 
            if (ItemSelected != null) {
                using (var args = new ItemSelectedEventArgs<SnippetControl>(this)) {
                    ItemSelected(this, args );
                }
            }
        }
         
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (ItemDbClick != null)
            {
                using (var args = new ItemSelectedEventArgs<SnippetControl>(this))
                {
                    ItemDbClick(this, args);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HideDeleteCheckBox();
        }

        private void SnippetControl_Disposed(object sender, EventArgs e)
        {
            Snippet = null;
        }

        public void SetSnippet(Snippet spp)
        {
            HideDeleteCheckBox();
            Snippet = spp;
            DataBind();
        }

        bool isDataBinding = false;
        private void DataBind()
        {
            isDataBinding = true;
            chkFavorite.Checked = false;
            if (Snippet != null)
            { 
                lbSnippetName.Text = Snippet.Name;
                chkFavorite.Checked = Snippet.IsFavorite;
            }
            isDataBinding = false;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // 설정 팝업!
            MessageBox.Show( Snippet.Name + "설정!");
        }
         
        #region 선택 처리용.  
        public bool IsSelected { get { return chkSelect.Checked; } }

        public void ShowDeleteCheckBox()
        {
            chkSelect.Checked = false;
            chkSelect.Visible = true;
        }

        public void HideDeleteCheckBox()
        {
            chkSelect.Checked = false;
            chkSelect.Visible = false;
        }
        #endregion

        private void lbSnippetName_Click(object sender, EventArgs e)
        {
            if (chkSelect.Visible)
                chkSelect.Checked = !chkSelect.Checked;

            OnClick(e);
        }

        private void lbSnippetName_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void chkFavorite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFavorite.Checked)
            {
                chkFavorite.BackgroundImage = Properties.Resources.Star_On;
            }
            else
            {
                chkFavorite.BackgroundImage = Properties.Resources.Star_Off;
            }

            if (isDataBinding) return;

            if (Snippet != null)
            {
                Snippet.IsFavorite = chkFavorite.Checked;
            }

            if (ChangeFavorite != null) ChangeFavorite(this, e);
        }
    }


    public class ItemSelectedEventArgs<T> : EventArgs, IDisposable
        where T : class, new()
    {
        public T Item { get; protected set; }
        public ItemSelectedEventArgs(T item) : base()
        {
            Item = item;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                    Item = null;
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~ItemSelectedEventArgs() {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
