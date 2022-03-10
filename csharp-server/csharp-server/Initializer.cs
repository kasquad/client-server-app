using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_server
{
    public class Initializer
    {
        private int id;
        public int ID { get { return id; } }

        public Initializer(int ID)
        {
            this.id = ID;
        }
    }
}
