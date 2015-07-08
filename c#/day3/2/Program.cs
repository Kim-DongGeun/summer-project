using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2
{
    public class Drink
    {
        public Drink() {}
        protected string m_name;
        protected string m_property;
        protected string m_type;
        public string NAME
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string PROPERTY
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string TPYE
        {
            get { return m_name; }
            set { m_name = value; }
        }
    }
    public class Wine : Drink
    {
        public Wine(string name, string property)
        {
            m_name = name;
            m_property = property;
            m_type = "wine";
        }
        public string name = "Wine";
        public string year = "1845";
    }
    public class Beer : Drink
    {
        public Beer(string name, string property)
        {
            m_name = name;
            m_property = property;
            m_type = "Beer";
        }
        public string name = "Beer";
        public string kind = "Lager";
    }
    public class Soju : Drink
    {
        public Soju(string name, string property)
        {
            m_name = name;
            m_property = property;
            m_type = "Soju";
        }
        public string name = "Soju";
        public string dosoo = "19";
    }
    class refrigerator
    {
        private List<Drink> list = new List<Drink>();
        public void run()
        {
            while (true)
            {
                Console.WriteLine("1. 넣기 2. 빼기 3. 조회 4. 종료");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    inputItems();
                }
                else if (input == "2")
                {
                    outputItems();
                }
                else if (input == "3")
                {
                    showlist();
                }
                else if (input == "4")
                {
                    break;
                }
            }
        }
        public void inputItems()
        {
            Console.WriteLine("1. 와인 2. 소주 3. 맥주");
            string Input = Console.ReadLine();
            if (Input == "1")
            {

                Console.WriteLine("술이름과 특징 입력");
                string Name = Console.ReadLine();
                string Property = Console.ReadLine();
                Drink Wine = new Wine(Name, Property);

            }
            else if (Input == "2")
            {
                Console.WriteLine("술이름과 특징 입력");
                string Name = Console.ReadLine();
                string Property = Console.ReadLine();
                Drink Soju = new Soju(Name, Property);
                list.Add(Soju);
            }
            else if (Input == "3")
            {
                Console.WriteLine("술이름과 특징 입력");
                string Name = Console.ReadLine();
                string Property = Console.ReadLine();
                Drink Beer = new Beer(Name, Property);
                list.Add(Beer);
            }
        }
        public void outputItems()
        {
            Console.WriteLine("제거할 술 이름 입력");
            string strinput = Console.ReadLine();
            int hold = 0;
            foreach (var i in list)
            {
                if (i.NAME == strinput)
                {
                    hold += 1;
                    break;
                }
            }
            if (hold == 0)
            {
                Console.WriteLine("Not Found");
            }
            int Index = 0;
            foreach (var j in list)
            {
                if (j.NAME == strinput)
                {
                    break;
                }
                else
                {
                    Index += 1;
                }
            }
            list.RemoveAt(Index);
        }
        public void showlist()
        {
            foreach (var k in list)
            {
                Console.WriteLine(k.NAME + ' ' + k.PROPERTY);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            refrigerator refri = new refrigerator();
            refri.run();
        }
    }
}