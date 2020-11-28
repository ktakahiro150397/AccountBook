﻿using System;
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
        public DbSet<Book> Book { get; set; }
    }
}
