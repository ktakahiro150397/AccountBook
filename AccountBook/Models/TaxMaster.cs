using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{
    public class TaxMaster
    {
        public int TaxMasterId { get; set; }

        /// <summary>
        /// この税項目の名前。
        /// </summary>
        [Required]
        public string TaxName { get; set; }

        /// <summary>
        /// この税項目がかける商品単価への税率(%)。
        /// </summary>
        [Required]
        public int TaxRate { get; set; }


    }
}
