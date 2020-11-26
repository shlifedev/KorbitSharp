 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Korbit.API.APIBase;

namespace Korbit.Model
{
    public class Balance : ResponseBase
    {
        /// <summary>
        /// 현재 거래 가능한 화폐의 수량.
        /// </summary>
        public float available;
        /// <summary>
        /// 	현재 거래중인 화폐의 수량.
        /// </summary>
        public float trade_in_use;
        /// <summary>
        /// 현재 출금이 진행중인 화폐의 수량.
        /// </summary>
        public float withdrawal_in_use;
        /// <summary>
        /// 코인의 경우 평균 매수단가
        /// </summary>
        public float avg_price;
        /// <summary>
        /// 평균 매수단가가 계산된 시각
        /// </summary>
        public long avg_price_updated_at;


        /// <summary>
        /// 거래중인 코인을 포함한 내가 구매한 코인의 평균 단가 
        /// </summary>
        public float AvgPrice
        {
            get
            {
                return avg_price / (available + trade_in_use);
            }
        }
        /// <summary>
        /// 거래중인 코인을 포함하지않은 내가 구매한 코인의 평균 단가 
        /// </summary>
        public float AvgPriceWithoutTrade
        {
            get
            {
                return avg_price / (available);
            }
        }
    }
}