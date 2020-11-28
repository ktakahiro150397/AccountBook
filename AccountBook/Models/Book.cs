using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountBook.Models
{
    ///テーブル名と同じ名前のクラス
        //検証ルールを追加する場合、IValidatableObjectを実装する
    public class Book:IValidatableObject
    {
        //主キーはId
        public int Id { get; set; }

        //カラム名と同じプロパティ名
        [DisplayName("書名")]
        [Required(ErrorMessage ="{0}の入力は必須です。")]
        public string Title { get; set; }
        
        [DisplayName("金額")]
        [DataType(DataType.Currency)]
        [Range(0,5000,ErrorMessage ="{0}は{1} - {2}円の範囲で入力してください。")]
        [Required(ErrorMessage = "{0}の入力は必須です。")]
        public int Price { get; set; }

        [StringLength(20,ErrorMessage = "{0}は{1}文字以内で入力してください。")]
        public string Publisher { get; set; }
        public bool Sample { get; set; }

        //検証ルールの実体
        //Validateメソッドを実装する(IValidatableObject)
        public IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            if(this.Publisher == "パブリッシャ" && this.Price != 1234)
            {
                //IEnumerable型で返す必要があるため、yieldで列挙する
                yield return new ValidationResult("パブリッシャの値段は1,234円以外入力できません。");
            }

        }

    }
}
