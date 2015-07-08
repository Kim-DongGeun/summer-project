using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class inform
    {
        public inform(int year, int month, int day, string content, int money, int total)
        {
            m_money = money;
            m_content = content;
            m_date.YEAR = year;
            m_date.MONTH = month;
            m_date.DAY = day;
            m_total += total;
        }
        Date m_date = new Date();
        private int m_total;
        private string m_content;
        private int m_money;
        public string CONTENT
        {
            get { return m_content; }
            set { m_content = value; }
        }
        public int TOTAL
        {
            get { return m_total; }
            set { m_total = value; }
        }
        public int MONEY
        {
            get { return m_money; }
            set { m_money = value; }
        }
        public Date DATE
        {
            get { return m_date; }
            set { m_date = value; }
        }
    }
}
