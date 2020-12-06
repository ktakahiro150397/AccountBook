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
        public int PaymentHeaderId { get; set; }

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
        [Required(ErrorMessage = "{0}の入力は必須です。")]
        [DisplayFormat(DataFormatString = "{0:MM}月")]
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
        [DisplayFormat(DataFormatString = "{0:###,0}円")]
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
        public virtual User User { get; set; }

        /// <summary>
        /// この明細に登録されている購入項目の一覧。
        /// </summary>
        [Required]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }


    }

    /// <summary>
    /// 明細ヘッダーの検索条件
    /// </summary>
    public class PaymentHeaderSearchCondition {

        /// <summary>
        /// 明細の名称。
        /// </summary>
        public string PaymentHeaderName { get; set; }

        /// <summary>
        /// 総額の下限額。
        /// </summary>
        public long? HeaderMoneyAmountFrom { get; set; }

        /// <summary>
        /// 総額の上限額。
        /// </summary>
        public long? HeaderMoneyAmountTo { get; set; }

        /// <summary>
        /// 購入項目の下限額(1項目あたりの金額で検索)。
        /// </summary>
        public long? DetailMoneyAmountFrom { get; set; }

        /// <summary>
        /// 購入項目の上限額(1項目あたりの金額で検索)。
        /// </summary>
        public long? DetailMoneyAmountTo { get; set; }

        /// <summary>
        /// 支払月の開始年(この年を含む)。
        /// </summary>
        public int? PaymentYearFrom {get;set;}

        /// <summary>
        /// 支払月の開始月(この月を含む)。
        /// </summary>
        public int? PaymentMonthFrom {get;set;}

        /// <summary>
        /// 支払月の終了年(この年を含む)。
        /// </summary>
        public int? PaymentYearTo {get;set;}

        /// <summary>
        /// 支払月の終了月(この月を含む)。
        /// </summary>
        public int? PaymentMonthTo {get;set; }

        /// <summary>
        /// 月の検索を、実際の支払月を対象に行う場合True。通常の支払い月を対象にする場合はFalse。
        /// </summary>
        public bool IsSearchActualMonth { get; set; }

        /// <summary>
        /// 明細メモの語句。
        /// </summary>
        public string PaymentHeaderMemo { get; set; }

        /// <summary>
        /// 明細の購入項目のメモの語句。
        /// </summary>
        public string PaymentDetailMemo { get; set; }

        /// <summary>
        /// 月調整済のデータを検索する場合はTrue。そうでない場合はFalse。
        /// </summary>
        public bool IsEqualized { get; set; }

        /// <summary>
        /// 月調整がされていないデータを検索する場合はTrue。そうでない場合はFalse。
        /// </summary>
        public bool IsNotEqualized { get; set; }

        /// <summary>
        /// 検索対象とする支出種別の値。
        /// </summary>
        public PaymentTypeMaster.PaymentTypeValue PaymentType { get; set; }

        /// <summary>
        /// 検索対象とするカテゴリの値。
        /// </summary>
        public CategoryMaster Category { get; set; }

        /// <summary>
        /// 検索対象とするユーザーの値。
        /// </summary>
        public User user { get; set; }

    }

}
