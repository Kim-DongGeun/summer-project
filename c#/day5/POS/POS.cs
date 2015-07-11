using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Pos
    {
        Set set = new Set();
        public List<Complete> completelist = new List<Complete>();
        public void run()
        {
            set.setMenu();
            Tabel[] Tabellist = new Tabel[10];
            while (true)
            {
                int[] count = new int[10];
                Console.WriteLine("input ID and password");
                string inputID = Console.ReadLine();
                if (inputID == "0")
                {
                    break;
                }
                string inputPW = Console.ReadLine();
                User user1 = new User("admin", "admin");
                User user2 = new User("2015104154", "1111");
                while (true)
                {
                    if (user1.m_ID == inputID && user1.m_PW == inputPW)//점장
                    {
                        Console.WriteLine("input salelist or cancel or back");
                        string inputoption = Console.ReadLine();
                        if (inputoption == "salelist")
                        {
                            int TOTAL = 0;
                            int I = 0;
                            Console.WriteLine("------------------------showlist-----------------------");
                            foreach (var item in completelist)
                            {
                                if (item == null)
                                {
                                    continue;
                                }
                                Console.WriteLine((I + 1) +".");
                                foreach(var ITEM in item.m_tabel.m_Orderlist)
                                {
                                    Console.WriteLine(ITEM.m_menu.menuName + " : " + ITEM.m_menuAmount + " ");
                                }
                                Console.WriteLine(item.m_total + "\t" + item.m_howto);
                                Console.WriteLine("-------------------------------------------------------");
                                I += 1;
                                TOTAL += item.m_total;
                            }
                            Console.WriteLine("TOTAL - " + TOTAL);
                            
                        }
                        else if (inputoption == "cancel")
                        {
                            int A = 0;
                            Console.WriteLine("Input number to cancel");
                            Console.Write("Enable number : ");
                            foreach (var item in completelist)
                            {
                                if (item == null)
                                {
                                    continue;
                                }
                                Console.Write((A+1) + " ");
                                A += 1;
                            }
                            Console.Write("\n");
                            int inputcancel = Int32.Parse(Console.ReadLine());
                            completelist[inputcancel - 1] = null;
                            Console.WriteLine("Success!");
                        }
                        else if (inputoption == "back")
                        {
                            break;
                        }
                    }
                    else if (user2.m_ID == inputID && user2.m_PW == inputPW)//사원
                    {
                        int total;
                        Console.WriteLine("input order, showlist, calculate, logout");
                        string inputoption1 = Console.ReadLine();
                        if (inputoption1 == "order")
                        {
                            Tabel tabel = new Tabel();
                            foreach (var I in set.Menulist)
                            {
                                Console.WriteLine(I.menuName + " : " + I.menuprice);
                            }
                            Console.WriteLine("input tabel number, customers number");
                            int inputtabel = Int32.Parse(Console.ReadLine());
                            int inputcustomer;
                            if (Tabellist[inputtabel - 1] == null)
                            {
                                inputcustomer = Int32.Parse(Console.ReadLine());
                            }
                            else
                            {
                                inputcustomer = Tabellist[inputtabel - 1].m_customers;
                            }
                            Console.WriteLine("input meun name, meun amount");
                            while (true)
                            {
                                int num = 0;
                                string menuName = Console.ReadLine();
                                if (menuName == "")
                                {
                                    break;
                                }
                                foreach (var menu in set.Menulist)
                                {
                                    if (menu.menuName == menuName)
                                    {
                                        num = 1;
                                        break;
                                    }
                                }
                                if (num == 0)
                                {
                                    Console.WriteLine("Not Found");
                                    continue;
                                }
                                int menuAmount = Int32.Parse(Console.ReadLine());
                                int INT = 0;
                                if (Tabellist[inputtabel - 1] != null)
                                {
                                    foreach (var i in Tabellist[inputtabel - 1].m_Orderlist)
                                    {
                                        if (menuName == i.m_menu.menuName)
                                        {
                                            i.m_menuAmount += menuAmount;
                                            INT = 1;
                                        }
                                    }
                                    if (INT == 1)
                                    {
                                        continue;
                                    }
                                    Order order1 = new Order(menuName, menuAmount);
                                    Tabellist[inputtabel - 1].m_Orderlist.Add(order1);
                                    count[inputtabel - 1] += 1;
                                    continue;
                                }
                                Order order = new Order(menuName, menuAmount);
                                tabel.m_customers = inputcustomer;
                                tabel.m_Orderlist.Add(order);
                                if (Tabellist[inputtabel - 1] == null)
                                {
                                    Tabellist[inputtabel - 1] = tabel;
                                }
                                else
                                {
                                    Tabellist[inputtabel - 1].m_Orderlist.Add(order);
                                }
                                count[inputtabel-1] += 1;
                            }
                        }
                        else if (inputoption1 == "showlist")
                        {
                            Console.WriteLine("------------------------showlist-----------------------");
                            for (int j = 0; j < 10; j++)
                            {
                                total = 0;
                                if (Tabellist[j] == null)
                                {
                                    continue;
                                }
                                Console.WriteLine("\nTabel Num - " + (j + 1));
                                for (int i = 0; i < count[j]; i++)
                                {
                                    int number = 0;
                                    foreach (var k in set.Menulist)
                                    {
                                        if (k.menuName == Tabellist[j].m_Orderlist[i].m_menu.menuName)
                                        {
                                            break;
                                        }
                                        number += 1;
                                    }
                                    Console.WriteLine(Tabellist[j].m_Orderlist[i].m_menu.menuName + " - " + Tabellist[j].m_Orderlist[i].m_menuAmount + "\t" + set.Menulist[number].menuprice * Tabellist[j].m_Orderlist[i].m_menuAmount);
                                    total += set.Menulist[number].menuprice * Tabellist[j].m_Orderlist[i].m_menuAmount;
                                }
                                Console.WriteLine("\nTotal : " + total);
                                Console.WriteLine("-------------------------------------------------------");
                            }
                        }
                        else if (inputoption1 == "calculate")
                        {
                            total = 0;
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
                                Console.Write("\n");
                                int tabelnum = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("how to pay : card or money");
                                string howto = Console.ReadLine();
                                if (howto != "card" && howto != "money")
                                {
                                    Console.WriteLine("Wrong input");
                                    continue;
                                }
                            foreach (var item in Tabellist[tabelnum-1].m_Orderlist)
                            {
                                Console.Write(item.m_menu.menuName + "(" + item.m_menuAmount + ") ");
                            }
                            foreach (var item in Tabellist[tabelnum-1].m_Orderlist)
                            {
                                total += item.m_menu.menuprice * item.m_menuAmount;
                            }
                            Complete complete = new Complete(total,howto,Tabellist[tabelnum-1]);
                            completelist.Add(complete);
                            Console.WriteLine("\nTotal : " + complete.m_total +"\nSuccess");
                            Tabellist[tabelnum - 1] = null;
                        }
                        else if(inputoption1 == "logout")
                        {
                            break;
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
    }
}


