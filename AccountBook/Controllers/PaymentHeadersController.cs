using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountBook.Models;

namespace AccountBook.Views.List
{
    public class PaymentHeadersController : Controller
    {
        private readonly MyContext _context;

        public PaymentHeadersController(MyContext context)
        {
            _context = context;
        }

    }
}
