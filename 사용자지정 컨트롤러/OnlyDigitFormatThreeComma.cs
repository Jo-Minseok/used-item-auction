using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deal_Program
{
    public partial class OnlyDigitFormatThreeComma : UserControl
    {
        public OnlyDigitFormatThreeComma()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text;
                text = textBox1.Text.Replace(",", "");
                textBox1.Text = String.Format("{0:#,###}", Convert.ToUInt64(text));
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("값을 너무 크게 입력하였습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void OnlyDigitFormatThreeComma_Load(object sender, EventArgs e)
        {

        }
    }
}
