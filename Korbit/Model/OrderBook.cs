using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Korbit.API.APIBase;

namespace Korbit.Model
{
    public class OrderBook : ResponseBase
    {
        /// <summary>
        /// 가장 마지막으로 유입된 호가의 주문 유입시각.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// [가격, 미체결잔량]으로 구성된 개별 호가를 나열한다. 3번째 값은 더이상 지원하지 않고 항상 "1"로 세팅된다.
        /// </summary>
        [JsonProperty("bids")]
        public List<List<float>> Bids { get; set; }

        /// <summary>
        /// [가격, 미체결잔량]으로 구성된 개별 호가를 나열한다. 3번째 값은 더이상 지원하지 않고 항상 "1"로 세팅된다.
        /// </summary>
        [JsonProperty("asks")]
        public List<List<float>> Asks { get; set; }
    }


}