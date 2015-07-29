using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public delegate void toForm3(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, bool b1, bool b2, bool b3);
    public partial class Form3 : Form
    {
        public static event toForm3 toform3;
        Form2 frm2;
        public int year = DateTime.Now.Year;
        public int month = DateTime.Now.Month;
        public int today = DateTime.Now.Day;
        public Form3(Form2 _frm2)
        {
            InitializeComponent();
            frm2 = _frm2;
            comboBox1.SelectedIndex = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm2.checkBox2.Checked = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toform3(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, comboBox3.SelectedIndex, comboBox4.SelectedIndex, radioButton1.Checked, radioButton2.Checked, radioButton3.Checked);
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label5.Text = "일";
                radioButton2.Visible = true;
                comboBox3.Visible = true; radioButton3.Visible = true;
                dateTimePicker1.Visible = true;
                comboBox4.Visible = false;
                label3.Text = "시작 날짜 :";                          
                textBox1.Text = Convert.ToString(year) + "." + Convert.ToString(month) + "." + Convert.ToString(today);
                textBox1.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {                
                label5.Text = "주";
                radioButton2.Visible = false;
                comboBox3.Visible = false; 
                label3.Text = "    반복일 :";                
                radioButton3.Visible = false;
                comboBox4.Visible = true;
                dateTimePicker1.Visible = false;
                textBox1.Visible = false;                
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Text = Convert.ToString(year) + "." + Convert.ToString(month) + "." + Convert.ToString(today);
                label3.Text = "시작 날짜 :";
                label5.Text = "개월";                                
                textBox1.Visible = true;                
                radioButton3.Visible = true;
                comboBox4.Visible = false;
                dateTimePicker1.Visible = true;
                radioButton2.Visible = true;
                comboBox3.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 3)
            {                
                textBox1.Text = Convert.ToString(year) + "." + Convert.ToString(month) + "." + Convert.ToString(today);
                label3.Text = "시작 날짜 :";
                label5.Text = "년";
                radioButton3.Visible = true;
                textBox1.Visible = true;
                comboBox4.Visible = false;
                dateTimePicker1.Visible = true;
                radioButton2.Visible = true;
                comboBox3.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox3.Enabled = true;
            }
            else
            {
                comboBox3.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }
    }
}
