﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountBook.Models;

namespace AccountBook.Controllers
{
    public class ListController : Controller
    {

        private readonly MyContext _context;

        public ListController(MyContext context)
        {
            _context = context;
        }


        // GET: PaymentHeaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.paymentHeaders.ToListAsync());
        }

        // GET: PaymentHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHeader = await _context.paymentHeaders
                .FirstOrDefaultAsync(m => m.PaymentHeaderId == id);
            if (paymentHeader == null)
            {
                return NotFound();
            }

            return View(paymentHeader);
        }

        // GET: PaymentHeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaymentName,PaymentMonth,ActuialPaymentMonth,DataCreatedDate,DataUpdateDate,Memo,MoneyAmount")] PaymentHeader paymentHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentHeader);
        }

        // GET: PaymentHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHeader = await _context.paymentHeaders.FindAsync(id);
            if (paymentHeader == null)
            {
                return NotFound();
            }
            return View(paymentHeader);
        }

        // POST: PaymentHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PaymentName,PaymentMonth,ActuialPaymentMonth,DataCreatedDate,DataUpdateDate,Memo,MoneyAmount")] PaymentHeader paymentHeader)
        {
            if (id != paymentHeader.PaymentHeaderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentHeaderExists(paymentHeader.PaymentHeaderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paymentHeader);
        }

        // GET: PaymentHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHeader = await _context.paymentHeaders
                .FirstOrDefaultAsync(m => m.PaymentHeaderId == id);
            if (paymentHeader == null)
            {
                return NotFound();
            }

            return View(paymentHeader);
        }

        // POST: PaymentHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentHeader = await _context.paymentHeaders.FindAsync(id);
            _context.paymentHeaders.Remove(paymentHeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentHeaderExists(int id)
        {
            return _context.paymentHeaders.Any(e => e.PaymentHeaderId == id);
        }
    }
}
