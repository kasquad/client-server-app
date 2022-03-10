using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace csharp_client
{
    class Client
    {
        private int _ID;
        private string _name;
        private bool _isInitialized = false;
        public bool IsInitialized { get { return _isInitialized; } }
        public void Init(string initializer)
        {

            var _initializer = JsonConvert.DeserializeObject<Initializer>(initializer);
            try
            {
                if (!(_initializer is Initializer))
                    throw new Exception();
                _ID = _initializer.ID;
                _isInitialized = true;
                Console.WriteLine("Client: initialization successful!");

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
