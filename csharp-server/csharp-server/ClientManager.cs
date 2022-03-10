using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_server
{
    public class ClientManager
    {
        private Dictionary<int, string> clients = new Dictionary<int, string>();

        public Dictionary<int,string> GetClients { get { return clients; } }

        private int idClient = 1;
        private int IdClient { get { return idClient++; } }

        public int AddClient(string name)
        {
            int id = IdClient;
            clients.Add(IdClient, name);
            return id;
        }
        public void PopClient(int id)
        {
            clients.Remove(id);
        }
        
    }
}
