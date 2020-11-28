using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountBook.ViewComponents
{
    //ビューコンポーネントはViewComponentクラスを継承する
    public class ListViewComponent:ViewComponent
    {
        

        private readonly MyContext myContext;

        //依存性のコンストラクタ注入
        public ListViewComponent(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //ビューコンポーネントの実処理
        public async Task<IViewComponentResult> InvokeAsync(int price)
        {
            //実処理メソッドの名称は"InvokeAsync"
            //IViewComponentResultを返す
            return View(await myContext.Book.Where(b => b.Price >= price).ToListAsync());
        }
    }
}
