using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PoiCSharpAnalyzer.UI
{
    class TextBoxLineNumbers
    {
        public static void UpdateLabelRowIndex(RichTextBox lineNumbers, RichTextBox textBox)
        {
            //we get index of first visible char and number of first visible line
            Point pos = new Point(0, 0);
            int firstIndex = textBox.GetCharIndexFromPosition(pos);
            int firstLine = textBox.GetLineFromCharIndex(firstIndex);

            //now we get index of last visible char and number of last visible line
            pos.X += textBox.ClientRectangle.Width;
            pos.Y += textBox.ClientRectangle.Height;
            int lastIndex = textBox.GetCharIndexFromPosition(pos);
            int lastLine = textBox.GetLineFromCharIndex(lastIndex);

            //this is point position of last visible char,
            //we'll use its Y value for calculating numberLabel size
            pos = textBox.GetPositionFromCharIndex(lastIndex);

            lineNumbers.Text = "";
            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                lineNumbers.Text += i + 1 + "\r\n";
            }
        }
    }
}
