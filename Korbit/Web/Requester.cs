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
        public string BaseURL => "https://api.korbit.co.kr/v1/";


        public async Task Get<T>(string resource, ParamBase content, bool isRequireToken, System.Action<T> callback)
        {
            WebRequest request = WebRequest.Create($"{BaseURL}{resource}{ReflectionUtility.MakeURLParameter(content)}");
            request.Method = "GET";
            if(isRequireToken) 
                request.Headers.Add("Authorization", $"{KorbitClient.CachedToken.token_type} {KorbitClient.CachedToken.access_token}");


            try
            {
                
                WebResponse response = await request.GetResponseAsync();
                HttpWebResponse httpResponse = response as HttpWebResponse;
                var statusCode = ((HttpWebResponse)response).StatusCode;
                string responseJson = "";
                if (statusCode == HttpStatusCode.OK)
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        responseJson = reader.ReadToEnd();
                        T responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseJson);
                        callback?.Invoke(responseObject);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(request.RequestUri);

            }
        }

        public async Task Post<T>(string resource, ParamBase content, System.Action<T> callback) where T : Korbit.API.APIBase.ResponseBase
        {
            await Post<T>(resource, content, false, callback);
        }
        public async Task Post<T>(string resource, ParamBase content, bool isRequireToken, System.Action<T> callback) where T : Korbit.API.APIBase.ResponseBase
        {  
            WebRequest request = WebRequest.Create($"{BaseURL}{resource}{ReflectionUtility.MakeURLParameter(content)}");
            request.Method = "POST";

            if (isRequireToken)
                request.Headers.Add("Authorization", $"{KorbitClient.CachedToken.token_type} {KorbitClient.CachedToken.access_token}");



            WebResponse response = await request.GetResponseAsync();
            HttpWebResponse httpResponse = response as HttpWebResponse;
            var statusCode = ((HttpWebResponse)response).StatusCode;
            string responseJson = "";
            if (statusCode == HttpStatusCode.OK)
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseJson = reader.ReadToEnd(); 

                    T responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseJson); 
                    callback?.Invoke(responseObject);
                }
            }
             
        }
    }
}
