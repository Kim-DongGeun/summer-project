using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class server
    {
        public Queue<int> queue = new Queue<int>();
        public void save(int count1)
        {
            queue.Enqueue(count1);
        }
    }
}
