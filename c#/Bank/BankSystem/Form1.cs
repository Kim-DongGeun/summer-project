using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class Form1 : Form
    {
        public server ser = new server();
        public int count = 0;
        public int count1 = 1;
        Form2 frm2 = new Form2();
        Form3 frm3 = new Form3();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "대기 인원 : " + (ser.queue.Count + 1);
            frm2.label3.Text = "대기 인원 : " + (ser.queue.Count + 1);
            frm3.label3.Text = "대기 인원 : " + (ser.queue.Count + 1);
            ser.save(count1);
            count1 += 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (count % 2 == 0)
            {
                try
                {
                    frm3.label2.Text = frm3.label2.Text.Replace(frm3.label2.Text, Convert.ToString(ser.queue.Dequeue()));
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                label1.Text = "대기 인원 : " + (ser.queue.Count);
                frm2.label3.Text = "대기 인원 : " + (ser.queue.Count );
                frm3.label3.Text = "대기 인원 : " + (ser.queue.Count);
                count += 1;
            }
            else
            {
                try
                {
                    frm2.label2.Text = frm2.label2.Text.Replace(frm2.label2.Text, Convert.ToString(ser.queue.Dequeue()));
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                label1.Text = "대기 인원 : " + (ser.queue.Count);
                frm2.label3.Text = "대기 인원 : " + (ser.queue.Count);
                frm3.label3.Text = "대기 인원 : " + (ser.queue.Count);
                count += 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm2.Show();
            frm3.Show();
        }
    }
}
