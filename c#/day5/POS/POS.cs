using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Pos
    {
        public List<Order> orderlist = new List<Order>();
        public void run()
        {
            Tabel[] Tabellist = new Tabel[10];

            while (true)
            {
                Console.WriteLine("input ID and password");
                string inputID = Console.ReadLine();
                string inputPW = Console.ReadLine();
                User user1 = new User("admin", "admin");
                User user2 = new User("2015104154", "1111");
                while (true)
                {
                    if (user1.m_ID == inputID && user1.m_PW == inputPW)//점장
                    {
                        Console.WriteLine("input salelist or cancel");
                        string inputoption = Console.ReadLine();
                        if (inputoption == "salelist")
                        {

                        }
                        else if (inputoption == "cancel")
                        {

                        }
                    }
                    else if (user2.m_ID == inputID && user2.m_PW == inputPW)//사원
                    {
                        Console.WriteLine("input order or showlist or calculate");
                        string inputoption1 = Console.ReadLine();
                        int count = 0;
                        if (inputoption1 == "order")
                        {
                            Console.WriteLine("input tabel number, customers number");
                            int inputtabel = Int32.Parse(Console.ReadLine());
                            int inputcustomer = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("input meun name, meun amount");
                            int num = 0;
                            while (true)
                            {
                                string menuName = "";
                                int menuAmount = 0;
                                string input = Console.ReadLine();
                                if (input == "")
                                {
                                    break;
                                }
                                foreach (var item in input)
                                {
                                    if (item == ' ')
                                    {
                                        num = 1;
                                    }
                                    else if (num == 0)
                                    {
                                        menuName += item;
                                    }
                                    else if (num == 1)
                                    {
                                        menuAmount = item;
                                    }
                                }
                                Order order = new Order(menuName, menuAmount);
                                orderlist.Add(order);
                            }
                            Tabel tabel = new Tabel(inputcustomer, orderlist);
                            Tabellist[inputtabel - 1] = tabel;
                            count += 1;
                        }
                        else if (inputoption1 == "showlist")
                        {
                            Console.WriteLine("-----------------showlist-----------------");
                            Console.WriteLine("\t\t\tMenu\t\tNumber\t\tSum");
                            for (int j = 0; j < 10; j++)
                            {
                                if (Tabellist[j] == null)
                                {
                                    continue;
                                }
                                Console.Write("Tabel Num - " + j + 1 + "\t\t");
                                for (int i = 0; i < count; i++)
                                {
                                    int number = 0;
                                    foreach (var k in Menulist)
                                    {
                                        if (k.menuName == orderlist[i].m_menu.menuName)
                                        {
                                            break;
                                        }
                                        number += 1;
                                    }
                                    Console.WriteLine("\t" + orderlist[i].m_menu.menuName + "\t\t" + orderlist[i].m_menuAmount + "\t\t" + Menulist[number].menuprice * orderlist[i].m_menuAmount);
                                }
                            }
                        }
                        else if (inputoption1 == "calculate")
                        {
                            Console.WriteLine("input tabel number");
                            Console.Write("Enable number :");
                            for (int I = 0; I < 10; I++)
                            {
                                if (Tabellist[I] == null)
                                {
                                    continue;
                                }
                                Console.Write(" " + (I + 1));
                            }
                            int tabelnum = Int32.Parse(Console.ReadLine());
                            foreach (var item in Tabellist[tabelnum].m_Orderlist)
                            {
                                Console.WriteLine(item.m_menu.menuName + "(" + item.m_menuAmount + ") ")
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                        break;
                    }
                }
            }
        }
        List<Menu> Menulist = new List<Menu>();
        public void setMenu()
        {
            Menu menu1 = new Menu();
            menu1.menuName = "규동";
            menu1.menuprice = 6500;
            Menulist.Add(menu1);
            Menu menu2 = new Menu();
            menu2.menuName = "가츠동";
            menu2.menuprice = 7000;
            Menulist.Add(menu2);
            Menu menu3 = new Menu();
            menu3.menuName = "에비동";
            menu3.menuprice = 7500;
            Menulist.Add(menu3);
            Menu menu4 = new Menu();
            menu4.menuName = "사케동";
            menu4.menuprice = 11000;
            Menulist.Add(menu4);
            Menu menu5 = new Menu();
            menu5.menuName = "하카타";
            menu5.menuprice = 7500;
            Menulist.Add(menu5);
            Menu menu6 = new Menu();
            menu6.menuName = "아카사카";
            menu6.menuprice = 7500;
            Menulist.Add(menu6);
            Menu menu7 = new Menu();
            menu7.menuName = "큐슈";
            menu7.menuprice = 8000;
            Menulist.Add(menu7);
            Menu menu8 = new Menu();
            menu8.menuName = "요코하마";
            menu8.menuprice = 8000;
            Menulist.Add(menu8);
            Menu menu9 = new Menu();
            menu9.menuName = "교자만두";
            menu9.menuprice = 5000;
            Menulist.Add(menu9);
            Menu menu10 = new Menu();
            menu10.menuName = "밥추가";
            menu10.menuprice = 1000;
            Menulist.Add(menu10);
        }
    }
}
