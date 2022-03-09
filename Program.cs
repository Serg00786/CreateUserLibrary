using CreateUserLibrary.BusinessLogic;
using CreateUserLibrary.Interfaces;
using System;
using System.Threading;

namespace CreateUserLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICreateUser create = new CreateUser();
            create.CreateNewUser();
        }
    }
}
