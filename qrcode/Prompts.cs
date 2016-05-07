using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qrcode
{
    public static class Prompts
    {
        public static int ShowDialog(string text, string caption, int defaultValue)
        {
            Form prompt = new Form();
            prompt.SizeGripStyle = SizeGripStyle.Hide;
            prompt.Width = 193;
            prompt.Height = 164;
            prompt.MaximumSize = prompt.Size;
            prompt.MinimumSize = prompt.Size;
            prompt.MaximizeBox = false;
            
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 13, Top = 22, Width = 146, Height = 13, Text = text };
            NumericUpDown inputBox = new NumericUpDown() {Value = defaultValue, Left = 12, Top = 53, Width = 156, Height = 20, Minimum = 15, Maximum = 200, Increment = 1, DecimalPlaces = 0 };
            Button confirmation = new Button() { Text = "Ok", Left = 93, Width = 75, Height = 23, Top = 90 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return (int)inputBox.Value;
        }
    }
}
