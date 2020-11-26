using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Korbit.API.APIBase;

namespace Korbit.Model
{
    public class TradeShopDetail : ResponseBase
    {
        /// <summary>
        /// 최종 체결 시각.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// 최종 체결 가격.
        /// </summary>
        [JsonProperty("last")]
        public float Last { get; set; }

        /// <summary>
        /// 최근 24시간 시작 가격.
        /// </summary>
        [JsonProperty("open")]
        public float Open { get; set; }

        /// <summary>
        /// 매수호가. 현재 매수 주문 중 가장 높은 가격.
        /// </summary>
        [JsonProperty("bid")]
        public float Bid { get; set; }

        /// <summary>
        /// 매도호가. 현재 매도 주문 중 가장 낮은 가격.
        /// </summary>
        [JsonProperty("ask")]
        public float Ask { get; set; }

        /// <summary>
        /// 최저가. 최근 24시간 동안의 체결 가격 중 가장 낮 가격.
        /// </summary>
        [JsonProperty("low")]
        public float Low { get; set; }

        /// <summary>
        /// 최고가. 최근 24시간 동안의 체결 가격 중 가장 높은 가격.
        /// </summary>
        [JsonProperty("high")]
        public float High { get; set; }

        /// <summary>
        /// 거래량.
        /// </summary>
        [JsonProperty("volume")]
        public float Volume { get; set; }

        /// <summary>
        /// 시작 가격 대비 현재가 차이.
        /// </summary>
        [JsonProperty("change")]
        public float Change { get; set; }

        /// <summary>
        /// 시작 가격 대비 현재가 차이 변화 비율.
        /// </summary>
        [JsonProperty("changePercent")]
        public float ChangePercent { get; set; }
    }


}