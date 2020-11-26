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
        public static async Task<Model.TradeShopDetail> ReqDetailed(ECurrencyPair currentcyPair, ECurrencyPair targetCurrentcyPair)
        {
            return await KorbitClient.requester.Get<Model.TradeShopDetail>("ticker/detailed", new DetailedParameter(currentcyPair, targetCurrentcyPair), false);
        }
        public static async Task<Model.TradeShopDetail> ReqDetailed(ECurrencyPair currentcyPair)
        {
            var targetCurrentcyPair = ECurrencyPair.krw;
            return await KorbitClient.requester.Get<Model.TradeShopDetail>("ticker/detailed", new DetailedParameter(currentcyPair, targetCurrentcyPair), false);
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
