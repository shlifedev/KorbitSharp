using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Korbit.API.APIBase;

namespace Korbit.Model
{
    public class TradeShopDetailAll : ResponseBase
    {
        public List<TradeShopDetail> detailedList = new List<TradeShopDetail>();
    }


}