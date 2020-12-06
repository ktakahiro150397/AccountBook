using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{
    public class CategoryMaster
    {
        public int CategoryMasterId { get; set; }

        /// <summary>
        /// カテゴリ名称。
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
        
        public virtual PaymentTypeMaster PaymentTypeMaster { get; set; }

    }
}
