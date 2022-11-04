﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mirea_Andreea_lab2.Data;
using Mirea_Andreea_lab2.Models;

namespace Mirea_Andreea_lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Mirea_Andreea_lab2.Data.Mirea_Andreea_lab2Context _context;

        public IndexModel(Mirea_Andreea_lab2.Data.Mirea_Andreea_lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}
