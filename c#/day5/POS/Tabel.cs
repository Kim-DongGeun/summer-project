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
        public Tabel(int customers, List<Order> Orderlist)
        {
            m_customers = customers;
            foreach (var item in Orderlist)
            {
                m_Orderlist.Add(item);
            }
        }
        public int m_customers;
    }
    public class Order
    {
        public Order(string menuName, int menuAmount)
        {
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
        public Tabel tabel;
        public int m_total;
        public string howto;
        //m_total = m_order.menu.menuprice * m_order.menuAmount;
    }
}
