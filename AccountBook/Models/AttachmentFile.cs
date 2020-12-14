using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{
    public class AttachmentFile
    {

        public int AttachmentFileId { get; set; }

        /// <summary>
        /// この添付ファイルの1から始まる連番。
        /// </summary>
        [DisplayName("No")]
        [Required()]
        public int Seq { get; set; }

        /// <summary>
        /// 添付ファイル本体。
        /// </summary>
        [Required()]
        public byte[] AttachFile { get; set; }

        /// <summary>
        /// この添付ファイルの名前。
        /// </summary>
        [Required()]
        public string AttachFileName { get; set; }

        /// <summary>
        /// この添付ファイルの拡張子。
        /// </summary>
        [Required()]
        public string AttachFileExtension { get; set; }

    }
}
