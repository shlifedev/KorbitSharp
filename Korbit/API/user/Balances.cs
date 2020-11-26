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
    /// <summary>
    /// 사용자의 정보, 잔고 등을 조회할 수 있다.
    /// </summary>
    public static class Balances
    {
        public static async Task<Model.Balances> ReqBalances()
        {
            return await KorbitClient.requester.Get<Model.Balances>("user/balances", null, true);
        }  
    }
}
