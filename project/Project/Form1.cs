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
    public partial class Form1 : Form
    {
        DBManager m = DBManager.getInstance();
        public string Saveday;
        public int count = 0;
        public int year = DateTime.Now.Year;
        public int month = DateTime.Now.Month;
        public int today = DateTime.Now.Day;
        public System.Windows.Forms.Label[] label;
        public int[] mon = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public Form1()
        {
            InitializeComponent();
            System.DateTime.Now.ToString("yyyy");
            DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            int day = 1;            
            int D = 0;
            int Date = 0;
            int a = 0;
            int K = (year * 365 + year / 4 - year / 100 + year / 400 + 1) % 7;
            Point Drawing_start = new Point(0, 80);
            Size Sizes = new Size(100, 70);
            Size margins = new Size(0, 0);
            this.label = new Label[42];   
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.label[a] = new Label();
                    this.label[a].BorderStyle = BorderStyle.FixedSingle;
                    this.label[a].Size = Sizes;
                    this.label[a].Location = new Point(j * (Sizes.Width + margins.Width) + Drawing_start.X, i * (Sizes.Height + margins.Height) + Drawing_start.Y);
                    this.label[a].TextAlign = ContentAlignment.TopRight;
                    this.label[a].Font = new Font("font", 10, FontStyle.Bold);
                    if (j == 0)
                    {
                        this.label[a].ForeColor = Color.Red;
                    }
                    if (j == 6)
                    {
                        this.label[a].ForeColor = Color.Blue;
                    }
                    this.Controls.Add(this.label[a++]);
                }
            }
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                if (month > 2)
                {
                    for (int k = 0; k < month - 1; k++)
                    {
                        D += mon[k];
                    }
                    D += 1;
                }
                else
                {
                    for (int l = 0; l < month - 1; l++)
                    {
                        D += mon[l];
                    }
                }
                Date = (K - 1 + (D % 7)) % 7;
            }
            else
            {
                for (int b = 0; b < month - 1; b++)
                {
                    D += mon[b];
                }
                Date = (K + (D % 7)) % 7;
            }
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                mon[1] = 29;
            }
                a = 0;
            switch (Date)
            {
                case 0://토 7
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 6].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 1://일 1
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 2://월 2
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 1].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 3:// 화 3
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 2].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 4://수 4
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 3].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 5://목 5
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 4].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 6://금 6
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 5].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
            }
            for (int t = 0; t < 42; t++)
            {
                label[t].MouseDown += new MouseEventHandler(label_Click);                
            }
            string QUERY = "select * from calendar";
            MySqlCommand Com = new MySqlCommand(QUERY, m.getDBConnection());
            MySqlDataReader READER = Com.ExecuteReader();
            int datacolor = 0;
            int datayear = 0;
            int datamonth = 0;
            int dataday = 0;
            while (READER.Read())
            {
                int count = 0;
                datayear = READER.GetInt32("year");
                datamonth = READER.GetInt32("month");
                dataday = READER.GetInt32("day");
                datacolor = READER.GetInt32("color");
                for (int i = 0; i < 42; i++)
                {
                    if (this.label[i].Text == Convert.ToString(dataday))
                    {
                        break;
                    }
                    count += 1;
                }
                if (datayear == year && datamonth == month && dataday == Convert.ToInt32(this.label[count].Text))
                {
                    this.label[count].BackColor = Color.FromArgb(datacolor);
                }
            }
            READER.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int day = 1;
            int[] mon = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int D = 0;
            int Date = 0;
            int a = 0;
            
            if (month == 1)
            {
                year -= 1;
                month = 12;
            }
            else
            {
                month -= 1;
            }
            int K = (year * 365 + year / 4 - year / 100 + year / 400 + 1) % 7;
            label8.Text = Convert.ToString(year) + "  " + Convert.ToString(month); 
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                if (month > 2)
                {
                    for (int k = 0; k < month - 1; k++)
                    {
                        D += mon[k];
                    }
                    D += 1;
                }
                else
                {
                    for (int l = 0; l < month - 1; l++)
                    {
                        D += mon[l];
                    }
                }
                Date = (K - 1 + (D % 7)) % 7;
                if (Date < 0)
                {
                    Date = 7 + Date;
                }
            }
            else
            {
                for (int b = 0; b < month - 1; b++)
                {
                    D += mon[b];
                }
                Date = (K + (D % 7)) % 7;
            }
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                mon[1] = 29;
            }
            a = 0;
            switch (Date)
            {
                case 0://토 7
                    for (int i = 0; i < 6; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                            this.label[a + 6].Text = Convert.ToString(day + l);
                            a += 1;
                    }
                    for (int k = mon[month - 1]+6; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                        break;
                case 1://일 1
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 2://월 2
                    for (int i = 0; i < 1; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 1].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+1; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 3:// 화 3
                    for (int i = 0; i < 2; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 2].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+2; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 4://수 4
                    for (int i = 0; i < 3; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 3].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+3; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 5://목 5
                    for (int i = 0; i < 4; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 4].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+4; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 6://금 6
                    for (int i = 0; i < 5; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 5].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+5; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
            }
            for (int l = 0; l < 42; l++)
            {
                this.label[l].BackColor = Color.White;
            }
            string QUERY = "select * from calendar";
            MySqlCommand Com = new MySqlCommand(QUERY, m.getDBConnection());
            MySqlDataReader READER = Com.ExecuteReader();
            int datacolor = 0;
            int datayear = 0;
            int datamonth = 0;
            int dataday = 0;
            while (READER.Read())
            {
                int count = 0;
                datayear = READER.GetInt32("year");
                datamonth = READER.GetInt32("month");
                dataday = READER.GetInt32("day");
                datacolor = READER.GetInt32("color");
                for (int i = 0; i < 42; i++)
                {
                    if (this.label[i].Text == Convert.ToString(dataday))
                    {
                        break;
                    }
                    count += 1;
                }
                if (datayear == year && datamonth == month && dataday == Convert.ToInt32(this.label[count].Text))
                {
                    this.label[count].BackColor = Color.FromArgb(datacolor);
                }
            }
            READER.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int day = 1;
            int[] mon = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int D = 0;
            int Date = 0;
            int a = 0;
            
            if (month == 12)
            {
                year += 1;
                month = 1;
            }
            else
            {
                month += 1;
            }
            int K = (year * 365 + year / 4 - year / 100 + year / 400 + 1) % 7;
            label8.Text = Convert.ToString(year) + "  " + Convert.ToString(month);
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                if (month > 2)
                {
                    for (int k = 0; k < month - 1; k++)
                    {
                        D += mon[k];
                    }
                    D += 1;
                }
                else
                {
                    for (int l = 0; l < month - 1; l++)
                    {
                        D += mon[l];
                    }
                }
                Date = (K - 1 + (D % 7)) % 7;
            }
            else
            {
                for (int b = 0; b < month - 1; b++)
                {
                    D += mon[b];
                }
                Date = (K + (D % 7)) % 7;
            }
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                mon[1] = 29;
            }
            if (Date < 0)
            {
                Date = 7 + Date;
            }
            a = 0;
            switch (Date)
            {
                case 0://토 7
                    for (int i = 0; i < 6; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 6].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+6; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 1://일 1
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 2://월 2
                    for (int i = 0; i < 1; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 1].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+1; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 3:// 화 3
                    for (int i = 0; i < 2; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 2].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+2; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 4://수 4
                    for (int i = 0; i < 3; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 3].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+3; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 5://목 5
                    for (int i = 0; i < 4; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 4].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+4; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
                case 6://금 6
                    for (int i = 0; i < 5; i++)
                    {
                        this.label[i].Text = "";
                    }
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 5].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    for (int k = mon[month - 1]+5; k < 42; k++)
                    {
                        this.label[k].Text = "";
                    }
                    break;
            }
            for (int l = 0; l < 42; l++)
            {
                this.label[l].BackColor = Color.White;
            }
            string QUERY = "select * from calendar";
            MySqlCommand Com = new MySqlCommand(QUERY, m.getDBConnection());
            MySqlDataReader READER = Com.ExecuteReader();
            int datacolor = 0;
            int datayear = 0;
            int datamonth = 0;
            int dataday = 0;
            while (READER.Read())
            {
                int count = 0;
                datayear = READER.GetInt32("year");
                datamonth = READER.GetInt32("month");
                dataday = READER.GetInt32("day");
                datacolor = READER.GetInt32("color");
                for (int i = 0; i < 42; i++)
                {
                    if (this.label[i].Text == Convert.ToString(dataday))
                    {
                        break;
                    }
                    count += 1;
                }
                if (datayear == year && datamonth == month && dataday == Convert.ToInt32(this.label[count].Text))
                {
                    this.label[count].BackColor = Color.FromArgb(datacolor);
                }
            }
            READER.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label8.Text = Convert.ToString(year) + "  " + Convert.ToString(month);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            int day = 1;
            int[] mon = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int D = 0;
            int Date = 0;
            int a = 0;
            int K = (year * 365 + year / 4 - year / 100 + year / 400 + 1) % 7;
            label8.Text = Convert.ToString(year) + "  " + Convert.ToString(month);
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                if (month > 2)
                {
                    for (int k = 0; k < month - 1; k++)
                    {
                        D += mon[k];
                    }
                    D += 1;
                }
                else
                {
                    for (int l = 0; l < month - 1; l++)
                    {
                        D += mon[l];
                    }
                }
                Date = (K - 1 + (D % 7)) % 7;
            }
            else
            {
                for (int b = 0; b < month - 1; b++)
                {
                    D += mon[b];
                }
                Date = (K + (D % 7)) % 7;
            }
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                mon[1] = 29;
            }
            a = 0;
            switch (Date)
            {
                case 0://토 7
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 6].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 1://일 1
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 2://월 2
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 1].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 3:// 화 3
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 2].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 4://수 4
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 3].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 5://목 5
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 4].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
                case 6://금 6
                    for (int l = 0; l < mon[month - 1]; l++)
                    {
                        this.label[a + 5].Text = Convert.ToString(day + l);
                        a += 1;
                    }
                    break;
            }
            for (int l = 0; l < 42; l++)
            {
                this.label[l].BackColor = Color.White;
            }
            string QUERY = "select * from calendar";
            MySqlCommand Com = new MySqlCommand(QUERY, m.getDBConnection());
            MySqlDataReader READER = Com.ExecuteReader();
            int datacolor = 0;
            int datayear = 0;
            int datamonth = 0;
            int dataday = 0;
            while (READER.Read())
            {
                int count = 0;
                datayear = READER.GetInt32("year");
                datamonth = READER.GetInt32("month");
                dataday = READER.GetInt32("day");
                datacolor = READER.GetInt32("color");
                for (int i = 0; i < 42; i++)
                {
                    if (this.label[i].Text == Convert.ToString(dataday))
                    {
                        break;
                    }
                    count += 1;
                }
                if (datayear == year && datamonth == month && dataday == Convert.ToInt32(this.label[count].Text))
                {
                    this.label[count].BackColor = Color.FromArgb(datacolor);
                }
            }
            READER.Close();
        }
        public void label_Click(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                try
                {
                    Saveday = Convert.ToString(sender.ToString()[34]);
                    try
                    {
                        Saveday += Convert.ToString(sender.ToString()[35]);
                    }
                    catch (IndexOutOfRangeException exception) { }
                    Form2 frm2 = new Form2(this);
                    frm2.Show();
                }
                catch (IndexOutOfRangeException indexout) { }
            }
            else if (e.Button == MouseButtons.Right)
            {
                try
                {
                    Saveday = Convert.ToString(sender.ToString()[34]);
                    try
                    {
                        Saveday += Convert.ToString(sender.ToString()[35]);
                    }
                    catch (IndexOutOfRangeException exception) { }
                    dataGridView1.Rows.Clear();
                    int count = 0;
                    string query = "select * from calendar";
                    MySqlCommand Command = new MySqlCommand(query, m.getDBConnection());
                    MySqlDataReader reader = Command.ExecuteReader();
                    int datayear = 0;
                    int datamonth = 0;
                    int dataday = 0;
                    string datatime = "";
                    string datacontent = "";
                    while (reader.Read())
                    {
                        datayear = reader.GetInt32("year");
                        datamonth = reader.GetInt32("month");
                        dataday = reader.GetInt32("day");
                        datacontent = reader.GetString("content");
                        datatime = reader.GetString("time");
                        if (datayear == year && datamonth == month && dataday == Convert.ToInt32(Saveday))
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[count].Cells[0].Value = datatime;
                            dataGridView1.Rows[count].Cells[1].Value = datacontent;                            
                            count += 1;
                        }
                    }
                    reader.Close();
                }
                catch (IndexOutOfRangeException index) { }
            }
        }        
        private void button5_Click(object sender, EventArgs e)
        {            
            string query = "delete from calendar where content='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value + "' and year=" + Convert.ToString(year) + " and month=" + Convert.ToString(month) +" and day=" + Saveday;
            MySqlCommand COMMAND = new MySqlCommand();
            COMMAND.Connection = m.getDBConnection();
            COMMAND.CommandText = query;
            COMMAND.ExecuteNonQuery();
            try
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            catch(ArgumentOutOfRangeException arg) {}
            string Query = "select * from calendar";
            MySqlCommand com = new MySqlCommand(Query, m.getDBConnection());
            MySqlDataReader Reader = com.ExecuteReader();
            int hold = 0;
            int Year = 0;
            int Month = 0;
            int Day = 0;
            while (Reader.Read())
            {
                Year = Reader.GetInt32("year");
                Month = Reader.GetInt32("month");
                Day = Reader.GetInt32("day");
                if (Year == year && Month == month && Day == Convert.ToInt32(Saveday))
                {
                    hold = 1;
                    break;
                }
            }
            if (hold == 0)
            {
                for (int i = 0; i < 42; i++)
                {
                    if (this.label[i].Text == Saveday)
                    {
                        break;
                    }
                    hold += 1;
                }
                this.label[hold].BackColor = Color.White;
            }
            Reader.Close();
        }
    }
}
