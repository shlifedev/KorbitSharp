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
using Korbit.Web;
using static Korbit.API.APIBase;

namespace Korbit.API.user
{
    public static class Balances
    {
        public static void ReqBalances(System.Action<Response> callback)
        {
            Requester.Get("user/balances", null, true, callback);
        } 

        public class BalancesParameter : ParamBase
        {
           
        } 
        public class Response  : ResponseBase
        {
            public class Currency {
                /// <summary>
                /// 현재 거래 가능한 화폐의 수량.
                /// </summary>
                public float available;
                /// <summary>
                /// 	현재 거래중인 화폐의 수량.
                /// </summary>
                public float trade_in_use;
                /// <summary>
                /// 현재 출금이 진행중인 화폐의 수량.
                /// </summary>
                public float withdrawal_in_use;
                /// <summary>
                /// 코인의 경우 평균 매수단가
                /// </summary>
                public float avg_price;
                /// <summary>
                /// 평균 매수단가가 계산된 시각
                /// </summary>
                public long avg_price_updated_at;


                /// <summary>
                /// 거래중인 코인을 포함한 내가 구매한 코인의 평균 단가 
                /// </summary>
                public float AvgPrice
                {
                    get
                    {
                        return avg_price / (available + trade_in_use);
                    }
                }
                /// <summary>
                /// 거래중인 코인을 포함하지않은 내가 구매한 코인의 평균 단가 
                /// </summary>
                public float AvgPriceWithoutTrade
                {
                    get
                    {
                        return avg_price / (available);
                    }
                }
            }
            public Currency aergo  { get; set; }
            public Currency bat    { get; set; }
            public Currency bch    { get; set; }
            public Currency bcha   { get; set; }
            public Currency bnb   { get; set; }
            public Currency bsv   { get; set; }
            public Currency btc   { get; set; }
            public Currency dai { get; set; }
            public Currency eos    { get; set; }
            public Currency etc    { get; set; }
            public Currency eth    { get; set; }
            public Currency fet    { get; set; }
            public Currency fil    { get; set; }
            public Currency krw    { get; set; }
            public Currency link  { get; set; }
            public Currency ltc    { get; set; }
            public Currency med   { get; set; }
            public Currency mkr    { get; set; }
            public Currency omg    { get; set; }
            public Currency poly    { get; set; }
            public Currency qtum   { get; set; }
            public Currency trx { get; set; }
            public Currency usdc { get; set; }
            public Currency xlm { get; set; }
            public Currency xrp { get; set; }
            public Currency zil { get; set; }
        }
    }
}
