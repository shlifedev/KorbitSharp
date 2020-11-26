using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korbit
{
    static class Program
    {
        static async Task X()
        {
            string[] idPass = System.IO.File.ReadAllLines("client_secret.txt");
            KorbitClient client = new KorbitClient(idPass[0],idPass[1]);

            await client.Login(x => { });
            await client.CheckBalances(x => {
                Console.WriteLine(x.etc);
            });
        }
        static void Main(string[] args)
        {
            X();
            Console.WriteLine("hello?");
            while (true) { }
        }
    }
}
