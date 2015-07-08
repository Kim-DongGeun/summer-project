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
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label[] label;
        public Form1()
        {
            InitializeComponent();

            int a = 0;
            Point Drawing_start = new Point(0, 100);
            Size Sizes = new Size(20, 20);
            Size margins = new Size(5, 5);
            this.label = new Label[42];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.label[a] = new Label();
                    this.label[a].Size = Sizes;
                    this.label[a].Location = new Point(j * (Sizes.Width + margins.Width) + Drawing_start.X, i * (Sizes.Height + margins.Height) + Drawing_start.Y);
                    this.label[a].TextAlign = ContentAlignment.TopRight;
                    if (j == 0)
                    {
                        this.label[a].ForeColor = Color.Red;
                    }
                    if (j == 6)
                    {
                        this.label[a].ForeColor = Color.Blue;
                    }
                    this.label[a].Text = "s";
                    this.Controls.Add(this.label[a++]);
                }
            }
        }

        private void monthCalendar1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Owner = this;
            frm.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker2.Enabled = false;
            }
            else if (checkBox1.Checked == false)
            {
                dateTimePicker2.Enabled = true;
            }
            if (checkBox1.Checked == true)
            {
                comboBox1.Visible = false;
            }
            else if (checkBox1.Checked == false)
            {
                comboBox1.Visible = true;
            }
            if (checkBox1.Checked == true)
            {
                comboBox2.Visible = false;
            }
            else if (checkBox1.Checked == false)
            {
                comboBox2.Visible = true;
            }
            if (checkBox1.Checked == true)
            {
                label2.Visible = false;
            }
            else if (checkBox1.Checked == false)
            {
                label2.Visible = true;
            }
        }
        
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Owner = this;
            frm.Show();
        }
    }
}
