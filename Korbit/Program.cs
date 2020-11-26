using Korbit.Model;
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

            await client.Login(x => {
                Console.WriteLine("Login Status : " + x);

              
               
            });
            await client.CheckBalances(balance =>
            {
                Console.WriteLine(balance.btc.available);
            });

            await client.CheckTradeShopDetailed(ECurrencyPair.ltc, detailed =>
            {

                Console.WriteLine(detailed.Low);
                Console.WriteLine(detailed.High);
                Console.WriteLine(detailed.Bid);

            });
        }

        static async Task Observe()
        {
            await Task.Run(() =>
            {

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
