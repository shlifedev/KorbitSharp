using Korbit.API.oauth2;
using Korbit.Model;
using Korbit.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Korbit
{
    //https://curl.olsh.me/
    public class KorbitClient
    {

        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string credentials = "client_credentials";
        private static Model.AccessToken cachedToken = null;
        public string ClientId => this.clientId;
        public string ClientSecret => this.clientSecret;
        public static Model.AccessToken CachedToken { get => cachedToken; set => cachedToken = value; }
        public static Requester requester;



        /// <summary>
        /// 코빗 클라이언트를 생성합니다.
        /// </summary>
        /// <param name="clientId"> 코빗에서 발급받은 클라이언트 id</param>
        /// <param name="clientSecret">코빗에서 발급받은 시크릿 키</param>
        public KorbitClient(string clientId, string clientSecret)
        {
            requester = new Requester(this);
            this.clientId = clientId;
            this.clientSecret = clientSecret;


        }

        /// <summary>
        /// 로그인 상태인지 확인합니다.
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            return CachedToken != null;
        }

        /// <summary>
        /// 잔고를 조회합니다.
        /// </summary>
        /// <returns></returns>
        public async Task<Model.Balance> CheckBalances()
        {
            return await API.user.Balances.ReqBalances();
        }
        /// <summary>
        /// 잔고를 조회합니다.
        /// </summary>
        /// <returns></returns>
        public async Task<Model.TradeShopDetail> CheckTradeShopDetailed(ECurrencyPair currentcyPair)
        {
            Console.WriteLine("CheckTradeShopDetailed..");
            return await API.ticker.Detailed.ReqDetailed(currentcyPair);
        }
        /// <summary>
        /// 코빗에 로그인합니다.
        /// </summary>
        public async Task<bool> Login(bool refreshToken)
        {
            
            if(refreshToken)
            {
                var token = await API.oauth2.AccessToken.ReqRefresh(clientId, clientSecret, CachedToken.refresh_token);
                if (token != null)
                {
                    CachedToken = token;
                    Console.WriteLine("토큰 리프래시됨.");
                    System.IO.File.WriteAllText("accessToken.json", Newtonsoft.Json.JsonConvert.SerializeObject(CachedToken));
                    return true;
                }
                else
                    return false;
            }
            if (System.IO.File.Exists("accessToken.json"))
            {
                Console.WriteLine("기존토큰으로 가져옴.");
                CachedToken = JsonConvert.DeserializeObject<Model.AccessToken>(System.IO.File.ReadAllText("accessToken.json")); 
                return true;
            }
            else
            {
                var token = await API.oauth2.AccessToken.ReqLogin(clientId, clientSecret);
    
                if (token != null)
                {
                    CachedToken = token;
                    Console.WriteLine("새 토큰을 요청하여 로그인 성공");
                    System.IO.File.WriteAllText("accessToken.json", Newtonsoft.Json.JsonConvert.SerializeObject(token));
                    return true;
                }
                else
                    return false;
            }



            return false;
        }
    }
}
