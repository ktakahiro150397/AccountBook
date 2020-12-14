using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{
    public class User
    {

        public int UserId { get; set; }

        /// <summary>
        /// この明細の名称。
        /// </summary>
        [DisplayName("ユーザー名")]
        [Required()]
        public string Name { get; set; }

        /// <summary>
        /// このユーザーのメールアドレス
        /// </summary>
        [DisplayName("メールアドレス")]
        public string MailAddress { get; set; }
        
        /// <summary>
        /// プロフィール画像
        /// </summary>
        public byte[] ProfilePicture { get; set; }
    }
}
