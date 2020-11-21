using Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private readonly IClient[] _clients;

        public Server()
        {
            // Some fancy stuff to make loading the clients easier
            // Don't need to understand this and you could just create them manually
            InjectionLoader<IClient> loader = new InjectionLoader<IClient>();
            _clients = loader.GetInjectedInstances().ToArray();
        }

        public async Task CallFunc1()
        {
            foreach (IClient client in _clients)
            {
                MessageA msg = new MessageA
                {
                    MemesInt = 420,
                    MemesStr = "420"
                };

                ResponseA recv = await client.Func1(msg);
                Console.WriteLine($"Server received {recv} from {client.Id}");
            }
        }

        public async Task CallFunc2()
        {
            foreach (IClient client in _clients)
            {
                MessageB msg = new MessageB
                {
                    MemesInt = 420,
                    MemesFloat = 4.3f
                };

                ResponseB recv = await client.Func2(msg);
                Console.WriteLine($"Server received {recv} from {client.Id}");
            }
        }
    }
}
