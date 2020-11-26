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
using static Korbit.API.APIBase;

namespace Korbit.API.oauth2
{
    public static class AccessToken
    {
        public static async Task ReqLogin(string id, string secret, System.Action<Korbit.Model.AccessToken> callback)
        {
            await KorbitClient.requester.Post("oauth2/access_token", new LoginParameter(id, secret), callback);
        }
        public static async Task ReqRefresh(string id, string secret, string refreshToken, System.Action<Korbit.Model.AccessToken> callback)
        {
            await KorbitClient.requester.Post("oauth2/access_token", new RefreshParameter(id, secret, refreshToken), callback);
        }

        public class LoginParameter : ParamBase
        {
            public string client_id;
            public string client_secret;
            public string grant_type = "client_credentials";

            public LoginParameter(string client_id, string client_secret)
            {
                this.client_id = client_id;
                this.client_secret = client_secret;
            }
        }
        public class RefreshParameter : ParamBase
        {
            public string client_id;
            public string client_secret;
            public string refresh_token; 
            public string grant_type = "refresh_token";

            public RefreshParameter(string client_id, string client_secret, string refresh_token)
            {
                this.client_id = client_id;
                this.client_secret = client_secret;
                this.refresh_token = refresh_token;
            }
        } 
    }
}
