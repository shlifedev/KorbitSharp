 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Korbit.API.APIBase;

namespace Korbit.Model
{
    public class Balances : ResponseBase
    {
        public Korbit.Model.Balance aergo { get; set; }
        public Korbit.Model.Balance bat { get; set; }
        public Korbit.Model.Balance bch { get; set; }
        public Korbit.Model.Balance bcha { get; set; }
        public Korbit.Model.Balance bnb { get; set; }
        public Korbit.Model.Balance bsv { get; set; }
        public Korbit.Model.Balance btc { get; set; }
        public Korbit.Model.Balance dai { get; set; }
        public Korbit.Model.Balance eos { get; set; }
        public Korbit.Model.Balance etc { get; set; }
        public Korbit.Model.Balance eth { get; set; }
        public Korbit.Model.Balance fet { get; set; }
        public Korbit.Model.Balance fil { get; set; }
        public Korbit.Model.Balance krw { get; set; }
        public Korbit.Model.Balance link { get; set; }
        public Korbit.Model.Balance ltc { get; set; }
        public Korbit.Model.Balance med { get; set; }
        public Korbit.Model.Balance mkr { get; set; }
        public Korbit.Model.Balance omg { get; set; }
        public Korbit.Model.Balance poly { get; set; }
        public Korbit.Model.Balance qtum { get; set; }
        public Korbit.Model.Balance trx { get; set; }
        public Korbit.Model.Balance usdc { get; set; }
        public Korbit.Model.Balance xlm { get; set; }
        public Korbit.Model.Balance xrp { get; set; }
        public Korbit.Model.Balance zil { get; set; }
    }
    /// <summary>
    /// 사용자의 정보 및 남은 잔고정보.
    /// </summary>
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

 
    }
}