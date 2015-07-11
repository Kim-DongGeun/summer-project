using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Tabel
    {
        public List<Order> m_Orderlist = new List<Order>();
        public int m_customers;
    }
    public class Set
    {
        public Menu[] Menulist = new Menu[10];
        public void setMenu()
        {
            Menu menu1 = new Menu();
            menu1.menuName = "규동";
            menu1.menuprice = 6500;
            Menulist[0] = menu1;
            Menu menu2 = new Menu();
            menu2.menuName = "가츠동";
            menu2.menuprice = 7000;
            Menulist[1] = menu2;
            Menu menu3 = new Menu();
            menu3.menuName = "에비동";
            menu3.menuprice = 7500;
            Menulist[2] = menu3;
            Menu menu4 = new Menu();
            menu4.menuName = "사케동";
            menu4.menuprice = 11000;
            Menulist[3] = menu4;
            Menu menu5 = new Menu();
            menu5.menuName = "하카타";
            menu5.menuprice = 7500;
            Menulist[4] = menu5;
            Menu menu6 = new Menu();
            menu6.menuName = "아카사카";
            menu6.menuprice = 7500;
            Menulist[5] = menu6;
            Menu menu7 = new Menu();
            menu7.menuName = "큐슈";
            menu7.menuprice = 8000;
            Menulist[6] = menu7;
            Menu menu8 = new Menu();
            menu8.menuName = "요코하마";
            menu8.menuprice = 8000;
            Menulist[7] = menu8;
            Menu menu9 = new Menu();
            menu9.menuName = "교자만두";
            menu9.menuprice = 5000;
            Menulist[8] = menu9;
            Menu menu10 = new Menu();
            menu10.menuName = "밥추가";
            menu10.menuprice = 1000;
            Menulist[9] = menu10; ;
        }
    }
    public class Order
    {
        public Order(string menuName, int menuAmount)
        {
            Set set = new Set();
            set.setMenu();
            int num = 0;
            foreach (var item in set.Menulist)
            {
                if (item.menuName == menuName)
                {
                    break;
                }
                num += 1;
            }
            m_menu.menuprice = set.Menulist[num].menuprice;
            m_menu.menuName = menuName;
            m_menuAmount = menuAmount;
        }
        public Menu m_menu = new Menu();
        public int m_menuAmount;
    }
    public class Menu
    {
        public string menuName;
        public int menuprice;
    }
    public class User
    {
        public User(string ID, string PW)
        {
            m_ID = ID;
            m_PW = PW;
        }
        public string m_ID;
        public string m_PW;
    }
    public class Complete
    {
        public Complete(int total, string howto, Tabel tabel)
        {
            m_total += total;
            m_howto = howto;
            m_tabel.m_customers = tabel.m_customers;
            m_tabel.m_Orderlist = tabel.m_Orderlist;
        }
        public Tabel m_tabel = new Tabel();
        public int m_total;
        public string m_howto;
    }
}
