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
        public static async Task ReqBalances(System.Action<Response> callback)
        {
            await KorbitClient.requester.Get("user/balances", null, true, callback);
        } 
         
        public class Response  : ResponseBase
        { 
            public Korbit.Model.Balance aergo  { get; set; }
            public Korbit.Model.Balance bat    { get; set; }
            public Korbit.Model.Balance bch    { get; set; }
            public Korbit.Model.Balance bcha   { get; set; }
            public Korbit.Model.Balance bnb   { get; set; }
            public Korbit.Model.Balance bsv   { get; set; }
            public Korbit.Model.Balance btc   { get; set; }
            public Korbit.Model.Balance dai { get; set; }
            public Korbit.Model.Balance eos    { get; set; }
            public Korbit.Model.Balance etc    { get; set; }
            public Korbit.Model.Balance eth    { get; set; }
            public Korbit.Model.Balance fet    { get; set; }
            public Korbit.Model.Balance fil    { get; set; }
            public Korbit.Model.Balance krw    { get; set; }
            public Korbit.Model.Balance link  { get; set; }
            public Korbit.Model.Balance ltc    { get; set; }
            public Korbit.Model.Balance med   { get; set; }
            public Korbit.Model.Balance mkr    { get; set; }
            public Korbit.Model.Balance omg    { get; set; }
            public Korbit.Model.Balance poly    { get; set; }
            public Korbit.Model.Balance qtum   { get; set; }
            public Korbit.Model.Balance trx { get; set; }
            public Korbit.Model.Balance usdc { get; set; }
            public Korbit.Model.Balance xlm { get; set; }
            public Korbit.Model.Balance xrp { get; set; }
            public Korbit.Model.Balance zil { get; set; }
        }
    }
}
