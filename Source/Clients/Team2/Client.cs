using Common;
using System.Threading.Tasks;

namespace Team2
{
    class Client : ClientBase
    {
        public override string Id => "Team B";

        public override Task<ResponseA> Func1(MessageA msg)
        {
            Log("func1 called");

            ResponseA response = new ResponseA
            {
                MemesInt = msg.MemesInt,
                MemesStr = msg.MemesStr
            };

            return Task.FromResult(response);
        }

        public override Task<ResponseB> Func2(MessageB msg)
        {
            Log("func2 called");

            ResponseB response = new ResponseB
            {
                MemesInt = msg.MemesInt,
                MemesFloat = msg.MemesFloat
            };

            return Task.FromResult(response);
        }
    }
}