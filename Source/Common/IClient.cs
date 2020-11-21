using System;
using System.Threading.Tasks;

namespace Common
{
    public interface IClient
    {
        string Id { get; }

        Task<ResponseA> Func1(MessageA msg);
        Task<ResponseB> Func2(MessageB msg);
    }
}
