 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Korbit.API.APIBase;

namespace Korbit.Model
{
    public class AccessToken : ResponseBase
    {
        public string token_type;
        public string access_token;
        public string expires_in;
        public string scope;
        public string refresh_token;
    }
}