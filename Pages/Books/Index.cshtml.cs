using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        public BookData BookID { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            BookID = new BookData();
           
            // using system
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
           
            CurrentFilter = searchString;
            
            BookD.Books = await _context.Book
                .Include(b => b.Author)
               .Include(b => b.Publisher)
               .Include(b => b.BookCategories)
               .ThenInclude(b => b.Categories)
               .AsNoTracking()
               .OrderBy(b => b.Title)
               .ToListAsync;
            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s => s.Author.FirstName.Contains(searchString)
                    || s.Author.LastName.Contains(searchString)
                    || s.Title.Contains(searchString));
            }
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.Categories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "title-desc":
                    BookD.Books = BookD.Books.OrderByDescending(s => s.Title);
                    break;
                case "author-desc":
                    BookD.Books = BookD.Books.OrderByDescending(s => s.Author.FullName);
                    break;
            }

        }
    
              
        }
    }
}
