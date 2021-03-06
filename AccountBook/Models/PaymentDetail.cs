﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{
    public class PaymentDetail
    {

        public int PaymentDetailId { get; set; }

        /// <summary>
        /// 支出種別
        /// </summary>
        [Required]
        public virtual PaymentTypeMaster PaymentType { get; set; }

        /// <summary>
        /// カテゴリ
        /// </summary>
        [Required]
        public virtual CategoryMaster Category { get; set; }
        

        /// <summary>
        /// この項目の合計金額
        /// </summary>
        [Required]
        public long MoneyAmount { get; set; }

        /// <summary>
        /// この項目の単価。
        /// </summary>
        [Required]
        public long UnitPrice { get; set; }

        /// <summary>
        /// この項目の個数。
        /// </summary>
        [Required]
        public int UnitCount { get; set; }

        /// <summary>
        /// この項目の名前。
        /// </summary>
        [Required]
        public string ItemName { get; set; }

        /// <summary>
        /// ユーザーが入力できるメモ。
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// この項目に設定する税区分。
        /// </summary>
        [Required]
        public virtual TaxMaster TaxType { get; set; }

        /// <summary>
        /// ヘッダーとのリレーション
        /// </summary>
        public virtual PaymentHeader PaymentHeader { get; set; }


    }
}
