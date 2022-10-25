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
    public partial class ParameterTextViewControl : UserControl
    {
        public event Action<string> ValueSelected = null;

        public bool HasParameterValues { get { return 0 < Controls.Count; } }

        private string[] ParameterValues
        {
            get
            {
                List<string> values = new List<string>();
                foreach (ParameterValueItemControl item in Controls)
                {
                    if (!values.Any(v => v == item.TextValue))
                    {
                        values.Add(item.TextValue);
                    }
                }
                return values.ToArray();
            }
        }

        public ParameterTextViewControl()
        {
            InitializeComponent();
            Height = 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Parent.Height = Height = AdjustHeight();
        }

        internal int AdjustHeight()
        {
            int height = 0;
            foreach (ParameterValueItemControl vc in Controls)
            {
                height += vc.Height;
            }
            return height;
        }

        internal void SetTextViews(SnippetParameter p)
        {
            DataClear();

            if (p != null && 0 < p.Values.Count)
            { 
                foreach (var value in p.Values)
                {
                    var valueControl = new ParameterValueItemControl();
                    valueControl.SetTextValue(value);
                    valueControl.DeleteClick += ValueControl_DeleteClick;
                    valueControl.DoubleClick += ValueControl_DoubleClick;
                    Controls.Add(valueControl);
                    valueControl.Dock = DockStyle.Top; 
                }
            }
            if(Parent != null)
            Parent.Height = Height = AdjustHeight();
        }

        internal string[] GetParameterValues(string text)
        {
            List<string> values = new List<string>(ParameterValues);

            if (values.Any(v => v.ToUpper() == text.ToUpper()) == false)
            {
                values.Insert(0, text);
            }
            return values.ToArray();
        }

        private void ValueControl_DoubleClick(object sender, EventArgs e)
        {
            // 선택!
            ParameterValueItemControl ctrl = sender as ParameterValueItemControl;
            if (ctrl != null)
            {
                if (ValueSelected != null)
                {
                    ValueSelected(ctrl.TextValue);
                }
            }
        }

        private void ValueControl_DeleteClick(object sender, EventArgs e)
        {
            ParameterValueItemControl ctrl = sender as ParameterValueItemControl;
            if (ctrl != null)
            {
                using (ctrl)
                {
                    Controls.Remove(ctrl);
                    ctrl.DeleteClick -= ValueControl_DeleteClick;
                    ctrl.DoubleClick -= ValueControl_DoubleClick; 
                }
                ctrl = null;
            }
            Parent.Height = Height = AdjustHeight(); 
        }

        private void DataClear()
        {
            for (int loop = Controls.Count - 1; loop >= 0; loop--)
            {
                using (Controls[loop])
                {
                    ParameterValueItemControl ctrl = Controls[loop] as ParameterValueItemControl;
                    if (ctrl != null)
                    {
                        ctrl.DeleteClick -= ValueControl_DeleteClick;
                        ctrl.DoubleClick -= ValueControl_DoubleClick;                      
                    }
                }
            }
            Height = 1;
            Controls.Clear();
        }
    }
}
