using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korbit
{
    static class Program
    {
        static async Task Connect()
        {
            string[] idPass = System.IO.File.ReadAllLines("client_secret.txt");
            KorbitClient client = new KorbitClient(idPass[0],idPass[1]);

            await client.Login(x => { }); 
        }

        static async Task Observe()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i);
                }
            }); 
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i*10);
                }
            }); 
        }
        static void Main(string[] args)
        {
            Connect();
            Observe();
            while (true) { }
        }
    }
}
