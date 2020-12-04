using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{

    /// <summary>
    /// 明細ヘッダー
    /// </summary>
    public class PaymentHeader
    {
        public int Id { get; set; }

        /// <summary>
        /// この明細の名称。
        /// </summary>
        [DisplayName("明細名")]
        [Required(ErrorMessage = "{0}の入力は必須です。")]
        public string PaymentName { get; set; }

        /// <summary>
        /// この明細の支払いを行った月。
        /// </summary>
        [DisplayName("支払月")]
        [Required(ErrorMessage ="{0}の入力は必須です。")]
        public DateTime PaymentMonth { get; set; }

        /// <summary>
        /// この明細を実際に支払った月。支払月と異なる場合、イレギュラー対応。
        /// </summary>
        [DisplayName("実際の支払月")]
        public DateTime ActuialPaymentMonth { get; set; }

        [DisplayName("明細作成日")]
        public DateTime DataCreatedDate { get; set; }

        [DisplayName("明細更新日")]
        public DateTime DataUpdateDate { get; set; }

        /// <summary>
        /// ユーザーが入力したメモ。
        /// </summary>
        [DisplayName("メモ")]
        public string Memo { get; set; }

        /// <summary>
        /// この明細の総額。税込み。
        /// </summary>
        [DisplayName("総額")]
        public long MoneyAmount { get; set; }
        
        /// <summary>
        /// この明細に添付されているファイル。
        /// </summary>
        public List<AttachmentFile> AttachFile { get; set; }

        /// <summary>
        /// この明細を入力したユーザー。
        /// </summary>
        [Required]
        [DisplayName("入力者")]
        public User User { get; set; }

        /// <summary>
        /// この明細に登録されている購入項目の一覧。
        /// </summary>
        [Required]
        public List<PaymentDetail> PaymentDetails { get; set; }
    }
}
