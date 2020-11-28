using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountBook.Models;

namespace AccountBook.Controllers
{
    //ControllerはすべてControllerクラスを継承する
    //"Controller"を除いたクラス名がURLに対応する
    public class HelloController : Controller
    {
        private readonly MyContext _myContext;

        public HelloController(MyContext myContext)
        {
            this._myContext = myContext;
        }


        //Controllerの中に含まれるアクションメソッドがリクエストを処理する
        //public修飾子
        //IActionResultを返すメソッド
        //メソッド名がURLに対応する
        //このアクションを呼び出すメソッドは~/hello/index
        public IActionResult Index()
        {
            //メソッド内部でヘルパーメソッドを使用してIActionResultを返却する
            return Content("Hello,world!");
        }
        
        public IActionResult Greet()
        {
            //Viewに渡す変数
            ViewBag.Message = "ViewBagから渡した文字列です！";

            //Viewヘルパーメソッドは、引数なしで呼ぶと既定のビューを呼び出す
            //"~/View/コントローラ名/アクション名.cshtml"
            //このメソッドでは、"~/View/Hello/Greet.cshtml"
            //引数を与えるとそのビューを呼び出す
            //View("hoge");なら、"~/View/Hello/hoge.cshtml"を呼び出す
            return View();
        }

        public IActionResult List()
        {
            //ビューにDBコンテキストを渡す
            return View(this._myContext.Book);
        }
    }
}
