using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class moneybook
    {
        private List<inform> list = new List<inform>();
        public int total = 0;
        public void run()
        {
            while (true)
            {
                Console.WriteLine("select option <input, showlist, search, end>");
                string strinput = Console.ReadLine();

                if (strinput == "input")
                {
                    input();
                }
                else if (strinput == "showlist")
                {
                    showlist();
                }
                else if (strinput == "search")
                {
                    search();
                }
                else if (strinput == "end")
                {
                    break;
                }
            }
        }
        public void search()
        {
            string year = "", month = "", day = "";
            int num = 0;
            Console.WriteLine("input year/month/day");
            string input = Console.ReadLine();
            foreach (var item in input)
            {
                if (item == '/')
                {
                    num += 1;
                    continue;
                }
                else if (item == '\n')
                {
                    num = 3;
                    continue;
                }
                if (num == 0)
                {
                    year += item;
                }
                else if (num == 1)
                {
                    month += item;
                }
                else if (num == 2)
                {
                    day += item;
                }
            }
            if (month == "")
            {
                int count = 0;
                int intA = Int32.Parse(year);
                Console.WriteLine("----------Search----------");
                Console.WriteLine("date\t\tcontent\t\tmoney");
                foreach (var item in list)
                {
                    if (intA == item.DATE.YEAR)
                    {
                        Console.WriteLine(item.DATE.YEAR + "." + item.DATE.MONTH + "." + item.DATE.DAY + "\t" + item.CONTENT + "\t\t" + item.MONEY);
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Not Found");
                }
                else if (count == 1)
                {
                    Console.WriteLine("----------------------------");
                }
            }
            else if (day == "")
            {
                int count = 0;
                int intA = Int32.Parse(year);
                int intB = Int32.Parse(month);
                Console.WriteLine("----------Search----------");
                Console.WriteLine("date\t\tcontent\t\tmoney\t\ttotal");
                foreach (var item in list)
                {
                    if (intA == item.DATE.YEAR && intB == item.DATE.MONTH)
                    {
                        Console.WriteLine(item.DATE.YEAR + "." + item.DATE.MONTH + "." + item.DATE.DAY + "\t" + item.CONTENT + "\t\t" + item.MONEY);
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Not Found");
                }
                else if (count == 1)
                {
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                int count = 0;
                int intA = Int32.Parse(year);
                int intB = Int32.Parse(month);
                int intC = Int32.Parse(day);
                Console.WriteLine("----------Search----------");
                Console.WriteLine("date\t\tcontent\t\tmoney\t\ttotal");
                foreach (var item in list)
                {
                    if (intA == item.DATE.YEAR && intB == item.DATE.MONTH && intC == item.DATE.DAY)
                    {
                        Console.WriteLine(item.DATE.YEAR + "." + item.DATE.MONTH + "." + item.DATE.DAY + "\t" + item.CONTENT);
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Not Found");
                }
                else if (count == 1)
                {
                    Console.WriteLine("----------------------------");
                }
            }
        }
        public void showlist()
        {
            Console.WriteLine("----------showlist----------");
            Console.WriteLine("date\t\tcontent\t\tmoney\t\ttotal");
            foreach (var item in list)
            {
                Console.WriteLine(item.DATE.YEAR + "." + item.DATE.MONTH + "." + item.DATE.DAY + "\t" + item.CONTENT + "\t\t" + item.MONEY + "\t\t" + item.TOTAL);
            }
            Console.WriteLine("----------------------------");
        }
        public void input()
        {
            int num = 0;
            string year = "", month = "", day = "";
            Console.WriteLine("input year/month/day, content, money");
            string date = Console.ReadLine();
            foreach (var item in date)
            {
                if (item == '/')
                {
                    num += 1;
                    continue;
                }
                if (num == 0)
                {
                    year += item;
                }
                else if (num == 1)
                {
                    month += item;
                }
                else if (num == 2)
                {
                    day += item;
                }
            }
            int intyear = Int32.Parse(year);
            int intmonth = Int32.Parse(month);
            int intday = Int32.Parse(day);
            string content = Console.ReadLine();
            int intmoney = Int32.Parse(Console.ReadLine());
            total += intmoney;
            inform Inform = new inform(intyear, intmonth, intday, content, intmoney, total);
            list.Add(Inform);
        }
    }
}
