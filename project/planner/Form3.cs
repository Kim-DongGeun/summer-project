using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace planner
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label8.Text = "매일";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label8.Text = "매주";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label8.Text = "매월";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                label8.Text = "매년";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                label8.Text += " 금요일";
            }
            else if (checkBox5.Checked == false)
            {
                label8.Text = label8.Text.Replace(" 금요일", "");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < 30; i++)
            {
                if (comboBox2.SelectedIndex == i && comboBox1.SelectedIndex == 0)
                {
                    label8.Text = (i + 1) + "일마다";
                }
                else if (comboBox2.SelectedIndex == i && comboBox1.SelectedIndex == 1)
                {
                    label8.Text = (i + 1) + "주마다";
                }
                else if (comboBox2.SelectedIndex == i && comboBox1.SelectedIndex == 2)
                {
                    label8.Text = (i + 1) + "개월마다";
                }
                else if (comboBox2.SelectedIndex == i && comboBox1.SelectedIndex == 3)
                {
                    label8.Text = (i + 1) + "년마다";
                }
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label8.Text += " 월요일";
            }
            else if (checkBox1.Checked == false)
            {
                label8.Text = label8.Text.Replace(" 월요일", "");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label8.Text += " 화요일";
            }
            else if (checkBox2.Checked == false)
            {
                label8.Text = label8.Text.Replace(" 화요일", "");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label8.Text += " 수요일";
            }
            else if (checkBox3.Checked == false)
            {
                label8.Text = label8.Text.Replace(" 수요일", "");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                label8.Text += " 목요일";
            }
            else if (checkBox4.Checked == false)
            {
                label8.Text = label8.Text.Replace(" 목요일", "");
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                label8.Text += " 토요일";
            }
            else if (checkBox6.Checked == false)
            {
                label8.Text = label8.Text.Replace(" 토요일", "");
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                label8.Text += " 일요일";
            }
            else if (checkBox7.Checked == false)
            {
                label8.Text = label8.Text.Replace(" 일요일", "");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (comboBox3.SelectedIndex == i && radioButton2.Checked == true)
                {
                    label8.Text = label8.Text + " " + (i + 1) + "주 반복";
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (comboBox3.SelectedIndex == i && radioButton1.Checked == true)
                {
                    label8.Text = label8.Text.Replace(" " + (i + 1) + "주 반복", "");
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox3.Enabled = true;
            }
            else if (radioButton2.Checked == false)
            {
                comboBox3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Owner = this;
            this.checkBox2.Checked = false;
            Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
