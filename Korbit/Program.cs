using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korbit
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] idPass = System.IO.File.ReadAllLines("client_secret.txt");
            KorbitClient client = new KorbitClient(idPass[0],idPass[1]);
            client.Login(); 

            client.CheckBalances( x=> {
                Console.WriteLine((x.ltc.AvgPrice));
            }); 
            while (true) { }
        }
    }
}
