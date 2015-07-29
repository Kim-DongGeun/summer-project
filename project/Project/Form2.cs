using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public int iColor;
        public int count = 0;
        public int saveindex1;
        public int saveindex2;
        public int saveindex3;
        public int saveindex4;
        public int saveindex5;
        public bool savebool1;
        public bool savebool2;
        public bool savebool3;
        public bool savebool4;
        public bool savebool5;
        public bool savebool6;
        public bool savebool7;
        public bool savebool8;
        public bool savebool9;
        public bool savebool10;
        public int saveyear;
        public int savemonth;
        public int saveday;
        DBManager m = DBManager.getInstance();
        
        public Form2(Form1 _frm1)
        {
            this.frm1 = _frm1;
            InitializeComponent();
            Form3.toform3 += new toForm3(Save);
            comboBox1.SelectedIndex = 20;
            dateTimePicker1.Value = new DateTime(frm1.year, frm1.month, Convert.ToInt32(frm1.Saveday));
            dateTimePicker2.Value = new DateTime(frm1.year, frm1.month, Convert.ToInt32(frm1.Saveday));
        }
        void Save(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, bool b1, bool b2, bool b3)
        {
            saveindex1 = i1;
            saveindex2 = i2;
            saveindex3 = i3;
            saveindex4 = i7;
            saveindex5 = i8;
            saveyear = i4;
            savemonth = i5;
            saveday = i6;
            savebool1 = b1;
            savebool2 = b2;
            savebool3 = b3;            
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            if (checkBox1.Checked == false)
            {
                label2.Visible = true;
                dateTimePicker2.Visible = true;
                comboBox1.Visible = false;
            }
            else
            {
                label2.Visible = false;
                dateTimePicker2.Visible = false;
                comboBox1.Visible = true;
                count += 1;
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                if (checkBox1.Checked == true)
                {
                    string inq = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = m.getDBConnection();
                    command.CommandText = inq;
                    command.Prepare();
                    command.Parameters.AddWithValue("@content", richTextBox1.Text);
                    command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                    command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                    command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                    command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                    command.Parameters.AddWithValue("@color", iColor);
                    command.ExecuteNonQuery();
                    Close();
                }
                else if (checkBox1.Checked == false)
                {
                    int sub = 0;
                    int subyear = dateTimePicker2.Value.Year - dateTimePicker1.Value.Year;
                    sub += subyear * 365;
                    int submonth = dateTimePicker2.Value.Month - dateTimePicker1.Value.Month;
                    for (int k = 0; k < submonth; k++)
                    {
                        if (frm1.year % 400 == 0 || (frm1.year % 4 == 0 && frm1.year % 100 != 0))
                        {
                            frm1.mon[1] = 29;
                        }
                        sub += frm1.mon[dateTimePicker1.Value.Month - 1 + k];
                    }
                    int subday = dateTimePicker2.Value.Day - dateTimePicker1.Value.Day;
                    sub += subday;
                    string save = richTextBox1.Text;
                    for (int j = 0; j < sub + 1; j++)
                    {
                        MySqlCommand command = new MySqlCommand();
                        command.Connection = m.getDBConnection();
                        command.CommandText = "insert into calendar (content, year, month, day, color) value (@Content, @Year, @Month, @Day, @Color)";
                        command.Prepare();
                        command.Parameters.AddWithValue("@Day", dateTimePicker1.Value.Day);
                        command.Parameters.AddWithValue("@Month", dateTimePicker1.Value.Month);
                        command.Parameters.AddWithValue("@Year", dateTimePicker1.Value.Year);
                        command.Parameters.AddWithValue("@Content", save);
                        command.Parameters.AddWithValue("@Color", iColor);
                        dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                        command.ExecuteNonQuery();
                        Close();
                    }
                }
            }
            else if (checkBox2.Checked == true)
            {
                if (saveindex1 == 0)
                {
                    if (savebool1 == true)
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year == 2020) { break; }                            
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(saveindex2+1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                    else if (savebool2 == true)
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year == frm1.year + (saveindex3 + 1) && dateTimePicker1.Value.Month == frm1.month && dateTimePicker1.Value.Day >= Convert.ToInt32(frm1.Saveday)) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                    else
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year >= saveyear && dateTimePicker1.Value.Month >= savemonth && dateTimePicker1.Value.Day >= saveday) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                }
                else if (saveindex1 == 1)
                {
                    if (savebool1 == true)
                    {
                        if (saveindex5 == 0)
                        {
                            string save = richTextBox1.Text;
                            while (true)
                            {
                                
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Monday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Wednesday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                                {
                                    if (dateTimePicker1.Value.Year == 2020) { break; }
                                    MySqlCommand command = new MySqlCommand();
                                    command.Connection = m.getDBConnection();
                                    command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                                    command.Prepare();
                                    command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                                    command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                                    command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                                    command.Parameters.AddWithValue("@content", save);
                                    command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                                    command.Parameters.AddWithValue("@color", iColor);
                                    command.ExecuteNonQuery();
                                    Close();
                                }
                                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                                
                            }
                        }
                        else if (saveindex5 == 1)
                        {
                            string save = richTextBox1.Text;
                            while (true)
                            {
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Tuesday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    if (dateTimePicker1.Value.Year == 2020) { break; }
                                    MySqlCommand command = new MySqlCommand();
                                    command.Connection = m.getDBConnection();
                                    command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                                    command.Prepare();
                                    command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                                    command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                                    command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                                    command.Parameters.AddWithValue("@content", save);
                                    command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                                    command.Parameters.AddWithValue("@color", iColor);
                                    command.ExecuteNonQuery();
                                    Close();
                                }
                                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                            }
                        }
                        else
                        {
                            string save = richTextBox1.Text;
                            while (true)
                            {
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    if (dateTimePicker1.Value.Year == 2020) { break; }
                                    MySqlCommand command = new MySqlCommand();
                                    command.Connection = m.getDBConnection();
                                    command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                                    command.Prepare();
                                    command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                                    command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                                    command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                                    command.Parameters.AddWithValue("@content", save);
                                    command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                                    command.Parameters.AddWithValue("@color", iColor);
                                    command.ExecuteNonQuery();
                                    Close();
                                }
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                                {
                                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(7 * saveindex2);
                                }
                                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                            }
                        }
                    }
                    else
                    {
                        if (saveindex5 == 0)
                        {
                            string save = richTextBox1.Text;
                            while (true)
                            {

                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Monday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Wednesday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                                {
                                    if (dateTimePicker1.Value.Year == 2020) { break; }
                                    MySqlCommand command = new MySqlCommand();
                                    command.Connection = m.getDBConnection();
                                    command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                                    command.Prepare();
                                    command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                                    command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                                    command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                                    command.Parameters.AddWithValue("@content", save);
                                    command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                                    command.Parameters.AddWithValue("@color", iColor);
                                    command.ExecuteNonQuery();
                                    Close();
                                }
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                                {
                                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(7 * saveindex2);
                                }
                                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);

                            }
                        }
                        else if (saveindex5 == 1)
                        {
                            string save = richTextBox1.Text;
                            while (true)
                            {
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Tuesday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    if (dateTimePicker1.Value.Year == 2020) { break; }
                                    MySqlCommand command = new MySqlCommand();
                                    command.Connection = m.getDBConnection();
                                    command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                                    command.Prepare();
                                    command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                                    command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                                    command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                                    command.Parameters.AddWithValue("@content", save);
                                    command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                                    command.Parameters.AddWithValue("@color", iColor);
                                    command.ExecuteNonQuery();
                                    Close();
                                }
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                                {
                                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(7 * saveindex2);
                                }
                                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                            }
                        }
                        else
                        {
                            string save = richTextBox1.Text;
                            while (true)
                            {
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    if (dateTimePicker1.Value.Year == 2020) { break; }
                                    MySqlCommand command = new MySqlCommand();
                                    command.Connection = m.getDBConnection();
                                    command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                                    command.Prepare();
                                    command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                                    command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                                    command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                                    command.Parameters.AddWithValue("@content", save);
                                    command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                                    command.Parameters.AddWithValue("@color", iColor);
                                    command.ExecuteNonQuery();
                                    Close();
                                }
                                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                                {
                                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(7 * saveindex2);
                                }
                                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                            }
                        }
                    }
                }
                else if (saveindex1 == 2)
                {
                    if (savebool1 == true)
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year == 2050) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                    else if (savebool2 == true)
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year == frm1.year + (saveindex3 + 1) && dateTimePicker1.Value.Month == frm1.month && dateTimePicker1.Value.Day >= Convert.ToInt32(frm1.Saveday)) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                    else
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year >= saveyear && dateTimePicker1.Value.Month >= savemonth && dateTimePicker1.Value.Day >= saveday) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                }
                else if (saveindex1 == 3)
                {
                    if (savebool1 == true)
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year == 2100) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                    else if (savebool2 == true)
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year == frm1.year + (saveindex3 + 1) && dateTimePicker1.Value.Month == frm1.month && dateTimePicker1.Value.Day >= Convert.ToInt32(frm1.Saveday)) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                    else
                    {
                        string save = richTextBox1.Text;
                        while (true)
                        {
                            if (dateTimePicker1.Value.Year >= saveyear && dateTimePicker1.Value.Month >= savemonth && dateTimePicker1.Value.Day >= saveday) { break; }
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = m.getDBConnection();
                            command.CommandText = "insert into calendar (content, time, year, month, day, color) values (@content, @time, @year, @month, @day, @color)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@day", dateTimePicker1.Value.Day);
                            command.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                            command.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                            command.Parameters.AddWithValue("@content", save);
                            command.Parameters.AddWithValue("@time", comboBox1.SelectedItem);
                            command.Parameters.AddWithValue("@color", iColor);
                            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(saveindex2 + 1);
                            command.ExecuteNonQuery();
                            Close();
                        }
                    }
                }                
            }
        }        
        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Text = "";
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Form3 frm3 = new Form3(this);
                frm3.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            for (int i = 0; i < 42; i++)
            {
               if (this.frm1.label[i].Text == this.frm1.Saveday)
                {
                    if (dateTimePicker2.Visible == false)
                    {
                        frm1.label[i].BackColor = colorDialog1.Color;
                    }
                    else if (dateTimePicker2.Visible == true)
                    {
                        int sub = 0;
                        int subyear = dateTimePicker2.Value.Year - dateTimePicker1.Value.Year;
                        sub += subyear * 365;
                        int submonth = dateTimePicker2.Value.Month - dateTimePicker1.Value.Month;
                        for(int k = 0; k < submonth; k++)
                        {
                            if (frm1.year % 400 == 0 || (frm1.year % 4 == 0 && frm1.year % 100 != 0))
                            {
                                frm1.mon[1] = 29;
                            }
                            sub += frm1.mon[dateTimePicker1.Value.Month - 1 + k];
                        }
                        int subday = dateTimePicker2.Value.Day - dateTimePicker1.Value.Day;
                        sub += subday;
                        for (int j = 0; j < sub + 1; j++)
                        {
                            this.frm1.label[i + j].BackColor = colorDialog1.Color;
                        }
                    }
                }
            }
            iColor = colorDialog1.Color.ToArgb();
        }
    }
}
