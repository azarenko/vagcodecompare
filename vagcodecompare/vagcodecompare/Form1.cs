using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vagcodecompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void compare_Click(object sender, EventArgs e)
        {
            byte[] code1 = StringToByte(code1tb.Text);
            byte[] code2 = StringToByte(code2tb.Text);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < code1.Length; i++)
            {
                sb.AppendLine(string.Format("Byte [{0}] 01234567 {1}", i.ToString().PadLeft(2, '0'), code1[i] != code2[i] ? "diff" : string.Empty));
                sb.AppendLine(string.Format("     [{0}] {1}", Convert.ToString(code1[i], 16).PadLeft(2, '0'), Reverse(Convert.ToString(code1[i], 2).PadLeft(8, '0'))));
                sb.AppendLine(string.Format("     [{0}] {1}", Convert.ToString(code2[i], 16).PadLeft(2, '0'), Reverse(Convert.ToString(code2[i], 2).PadLeft(8, '0'))));
                sb.AppendLine();
            }

            result.Text = sb.ToString();
        }

        private string Reverse(string input)
        {
            char[] inputarray = input.ToCharArray();
            Array.Reverse(inputarray);
            return new string(inputarray);
        }

        private byte[] StringToByte(string code)
        {
            byte[] buffer = new byte[code.Length / 2];

            for (int i = 0; i < code.Length; i+=2)
            {
                buffer[i / 2] = byte.Parse(code.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return buffer;
        }
    }
}
