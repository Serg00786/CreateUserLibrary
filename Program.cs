using CreateUserLibrary.BusinessLogic;
using CreateUserLibrary.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreateUserLibrary
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ICreateUser create = new CreateUser();
            await create.CreateNewUser();
        }
    }
}
