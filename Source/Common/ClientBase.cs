using System;
using System.Threading.Tasks;

namespace Common
{
    public abstract class ClientBase : IClient
    {
        public abstract string Id { get; }

        public abstract Task<ResponseA> Func1(MessageA msg);
        public abstract Task<ResponseB> Func2(MessageB msg);

        protected void Log(string msg)
        {
            Console.WriteLine($"{Id}: {msg}");
        }
    }
}