using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AccountBook.Models
{
    /// モデルクラスとDBの橋渡しを行うコンテキストクラス
    /// DbContextクラスを継承する
    public class MyContext : DbContext
    {
        // コンストラクタでDbContextOptions<TContext>の引数を取り、基底クラスのコンストラクタに渡す
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        // モデルクラスと同名で、DbSet<TModel>型のプロパティを持つ
        public DbSet<AttachmentFile> attachmentFiles { get; set; }
        public DbSet<CategoryMaster> categoryMasters { get; set; }
        public DbSet<PaymentHeader> paymentHeaders { get; set; }
        public DbSet<PaymentDetail> paymentDetails { get; set; }
        public DbSet<PaymentTypeMaster> paymentTypeMasters { get; set; }
        public DbSet<TaxMaster> taxMasters { get; set; }
        public DbSet<User> users { get; set; }


    }
}
