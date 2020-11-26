using Korbit;
using Korbit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProgram
{
    static class Program
    {
        static async Task Connect()
        {
            string[] idPass = System.IO.File.ReadAllLines("client_secret.txt");
            KorbitClient client = new KorbitClient(idPass[0],idPass[1]);

            var login = await client.Login(false);
            if (login)
            {
                var balance = await client.CheckBalances();
                var tradeShop = await client.CheckTradeShopDetailed(ECurrencyPair.ltc);
                Console.WriteLine("LTC 구매한 평단가 : " + balance.ltc.avg_price);
                Console.WriteLine("LTC 가격 : " + tradeShop.Bid);

            }
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
            while (true)
            {
            }
        }
    }
}
