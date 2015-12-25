using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoiCSharpAnalyzer.UI
{
    class AutoresizeForm
    {
        public class ControlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }

        private ControlRect formCR;
        private List<ControlRect> controlList;

        public void InitializeForm(Form mForm)
        {
            controlList = new List<ControlRect>();

            formCR = new ControlRect();
            formCR.Left = mForm.Left;
            formCR.Top = mForm.Top;
            formCR.Width = mForm.Width;
            formCR.Height = mForm.Height;

            foreach (Control c in mForm.Controls)
            {
                ControlRect objCR = new ControlRect();
                objCR.Left = c.Left;
                objCR.Top = c.Top;
                objCR.Width = c.Width;
                objCR.Height = c.Height;
                controlList.Add(objCR);
            }
        }

        public void Resize(Form mForm)
        {
            if (formCR == null)
            {
                InitializeForm(mForm);
            }

            double wScale = (double)mForm.Width / (double)formCR.Width;
            double hScale = (double)mForm.Height / (double)formCR.Height;

            int i = 0;
            foreach (Control c in mForm.Controls)
            {
                c.Left = (int)(controlList[i].Left * wScale);
                c.Top = (int)(controlList[i].Top * hScale);
                c.Width = (int)(controlList[i].Width * wScale);
                c.Height = (int)(controlList[i].Height * hScale);
                i++;
            }
        }
    }
}
