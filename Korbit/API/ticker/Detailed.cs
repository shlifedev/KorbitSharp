using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Korbit.API;
using Korbit.Model;
using Korbit.Web;
using static Korbit.API.APIBase;

namespace Korbit.API.ticker
{
    public static class Detailed
    {
        public static async Task ReqDetailed(ECurrencyPair currentcyPair, ECurrencyPair targetCurrentcyPair, System.Action<Model.TradeShopDetail> detail)
        {
            await KorbitClient.requester.Get("ticker/detailed", new DetailedParameter(currentcyPair, targetCurrentcyPair), false, detail);
        }
        public static async Task ReqDetailed(ECurrencyPair currentcyPair, System.Action<Model.TradeShopDetail> detail)
        {
            var targetCurrentcyPair = ECurrencyPair.krw;
            await KorbitClient.requester.Get("ticker/detailed", new DetailedParameter(currentcyPair, targetCurrentcyPair), false, detail);
        }

        public class DetailedParameter : ParamBase
        {
            public string currency_pair;

            public DetailedParameter(ECurrencyPair currency_pair, ECurrencyPair currency_pair2)
            {
                this.currency_pair = $"{currency_pair}_{currency_pair2}";
            }
        }
    }
}
