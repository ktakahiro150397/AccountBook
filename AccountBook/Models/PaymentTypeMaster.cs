using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{
    public class PaymentTypeMaster
    {

        public int PaymentTypeMasterId { get; set; }

        /// <summary>
        /// 支出種別名。
        /// </summary>
        [Required]
        public string PaymentTypeName { get; set; }

        /// <summary>
        /// 支出種別を表す値。
        /// </summary>
        [Required]
        public PaymentTypeValue PaymentType { get; set; }

        /// <summary>
        /// この支出種別に紐づくカテゴリが変更可能かどうかを表すブール値。
        /// </summary>
        [Required]
        public bool IsCategoryChangable { get; set; }

        ///// <summary>
        ///// 既定で選択されているカテゴリの項目。
        ///// </summary>
        //[Required]
        //public CategoryMaster DefaultCategory { get; set; }

        /// <summary>
        /// この支出種別に属するカテゴリの項目。
        /// </summary>
        [Required]
        public virtual ICollection<CategoryMaster> Category { get; set; }

        /// <summary>
        /// この支出種別が属するグループ。
        /// </summary>
        [Required]
        public PaymentTypeGroup Group { get; set; }

        /// <summary>
        /// 支出タイプの値を表します。
        /// </summary>
        public enum PaymentTypeValue
        {
            /// <summary>
            /// 家庭支出。
            /// </summary>
            Family,

            /// <summary>
            /// 固定支出。
            /// </summary>
            Fixed,

            /// <summary>
            /// 個人支出。
            /// </summary>
            Individual,

            /// <summary>
            /// 控除。
            /// </summary>
            Deduction,

            /// <summary>
            /// 持ち出し。
            /// </summary>
            Debt
        }

        /// <summary>
        /// 支出種別のグループを表します。
        /// </summary>
        public enum PaymentTypeGroup
        {
            FamilyGroup,
            IndividualGroup,
            DeductionGroup,
            DebtGroup
        }

    }

    
}
