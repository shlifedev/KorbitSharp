using Korbit.API.oauth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korbit
{
    //https://curl.olsh.me/
    public class KorbitClient
    { 
        private readonly string clientId;
        private readonly string clientSecret;  
        private readonly string credentials = "client_credentials";
        private static API.oauth2.AccessToken.Response cachedToken = null;
        public string ClientId => this.clientId; 
        public string ClientSecret => this.clientSecret; 
        public static AccessToken.Response CachedToken { get => cachedToken; set => cachedToken = value; }

       

        /// <summary>
        /// 코빗 클라이언트를 생성합니다.
        /// </summary>
        /// <param name="clientId"> 코빗에서 발급받은 클라이언트 id</param>
        /// <param name="clientSecret">코빗에서 발급받은 시크릿 키</param>
        public KorbitClient(string clientId, string clientSecret)
        {
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
        public void CheckBalances(System.Action<API.user.Balances.Response> callback)
        {
            API.user.Balances.ReqBalances(callback);
        }
        /// <summary>
        /// 코빗에 로그인합니다.
        /// </summary>
        public void Login()
        {
            if (CachedToken == null)
            {
                API.oauth2.AccessToken.ReqLogin(clientId, clientSecret, token =>
                {
                    CachedToken = token;  
                });
                Console.WriteLine("Login Succesfully!");
            }
            else
            {
                API.oauth2.AccessToken.ReqRefresh(clientId, clientSecret, CachedToken.refresh_token, token =>
                {
                    CachedToken = token;
                });
                Console.WriteLine("Login(Refresh) Succesfully!");
            } 
        } 
    }
}
