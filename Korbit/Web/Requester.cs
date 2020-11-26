using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Korbit.API.APIBase;

namespace Korbit.Web
{
    public class Requester
    {
        KorbitClient client;

        public Requester(KorbitClient client)
        {
            this.client = client;
        }

        public string BaseURL => "https://api.korbit.co.kr/v1/";


        public async Task<T> Get<T>(string resource, ParamBase content, bool isRequireToken) where T : Korbit.API.APIBase.ResponseBase
        {
            WebRequest request = WebRequest.Create($"{BaseURL}{resource}{ReflectionUtility.MakeURLParameter(content)}");
            request.Method = "GET";
            request.Timeout = 3000;
            if (isRequireToken)
            {
                if(KorbitClient.CachedToken == null) 
                    throw new Exception("Token Null!"); 
                request.Headers.Add("Authorization", $"{KorbitClient.CachedToken.token_type} {KorbitClient.CachedToken.access_token}");
            } 
              
            WebResponse response = await request.GetResponseAsync(); 
            HttpWebResponse httpResponse = response as HttpWebResponse; 
            var statusCode = ((HttpWebResponse)response).StatusCode;
            Console.WriteLine("get status code : " + statusCode);
            string responseJson = "";
        
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                var result = await client.Login(true);
                if (result == true)
                { 
                    Console.WriteLine("retry request");
                    return await Get<T>(resource, content, isRequireToken);
                }
                else
                {
                    throw new Exception("Unknown Error =>" + statusCode);
                }
            }
            if (statusCode == HttpStatusCode.OK)
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseJson = reader.ReadToEnd();
                    T responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseJson);
                    return responseObject;
                }
            }

            return null;
        }

        public async Task<T> Post<T>(string resource, ParamBase content) where T : Korbit.API.APIBase.ResponseBase
        {
            return await Post<T>(resource, content, false);
        }
        public async Task<T> Post<T>(string resource, ParamBase content, bool isRequireToken) where T : Korbit.API.APIBase.ResponseBase
        {
            WebRequest request = WebRequest.Create($"{BaseURL}{resource}{ReflectionUtility.MakeURLParameter(content)}");
            request.Method = "POST";
            request.Timeout = 2000;
            if (isRequireToken) 
                request.Headers.Add("Authorization", $"{KorbitClient.CachedToken.token_type} {KorbitClient.CachedToken.access_token}"); 

            Console.WriteLine(request.RequestUri);
            WebResponse response = await request.GetResponseAsync();

            Console.Write(response);
            HttpWebResponse httpResponse = response as HttpWebResponse;
            var statusCode = ((HttpWebResponse)response).StatusCode;
            Console.WriteLine("status code : " + statusCode);
            string responseJson = "";
             
 
            if (statusCode == HttpStatusCode.OK)
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseJson = reader.ReadToEnd();
                    T responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseJson);
                    return responseObject;
                }
            }

            return null;
        }
    }
}
