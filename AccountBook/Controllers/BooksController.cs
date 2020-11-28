using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountBook.Models;

namespace AccountBook.Controllers
{
    public class BooksController : Controller
    {
        private readonly MyContext _context;

        public BooksController(MyContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            //テーブルから、重複なしで出版社名を取得する
            var list = this._context.Book.Select(item => new { Publisher = item.Publisher }).Distinct();

            ViewBag.publisherOpt = new SelectList(list, "Publisher", "Publisher");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Publisher,Sample")] Book book)
        {
            //このアクションはPOST時に呼び出される

            //引数にはBook型データを割り当てられる
            //ただし、この場合はBind属性でプロパティ名を明示的に指定する必要がある

            if (ModelState.IsValid)
            {
                //コンテキストに入力データを追加する
                _context.Add(book);

                //コンテキストの変更を保存する
                await _context.SaveChangesAsync();

                //変更の保存後、一覧へリダイレクトする
                //文字列で指定せず、nameof(Method)で指定する
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //キーを渡してそのデータを取得するFindメソッドの非同期版
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Publisher,Sample")] Book book)
        {
            //hiddenで持っている、画面中のIDと、URLパラメータを比較する
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //コンテキストに対してモデルの更新を通知
                    _context.Update(book);
                    //モデルの更新を保存
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //変更の競合が発生した場合(オプティミスティック排他制御)

                    if (!BookExists(book.Id))
                    {
                        //対象のデータが存在しない場合
                        return NotFound();
                    }
                    else
                    {
                        //その他(他ユーザーに更新された場合)
                        //再スロー
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        //ActionName属性で、アクション名称を指定できる
        //→アクションメソッドの名称と分離できる/同じ引数のGET・POSTメソッドを区別できる
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            //処理後、一覧へ戻る
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
