using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm_PSO_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.OutputEncoding = Encoding.UTF8;
            Login login = new Login();
            login.AdminOrUser();
            Console.ReadKey();
        }
    }
}
