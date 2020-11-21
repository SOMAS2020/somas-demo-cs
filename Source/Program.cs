using System;
using System.Threading.Tasks;

class Program
{
    private static async Task Main(string[] args)
    {
        Server.Server server = new Server.Server();
        await server.CallFunc1();
        await server.CallFunc2();
    }
}