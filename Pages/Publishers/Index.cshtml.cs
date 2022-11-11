using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mirea_Andreea_lab2.Models;

namespace Mirea_Andreea_lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Mirea_Andreea_lab2.Data.Mirea_Andreea_lab2Context _context;
        private object await_context;

        public IndexModel(Mirea_Andreea_lab2.Data.Mirea_Andreea_lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;

        public async Task OnGetAsync()
        {
            {
                Book = await _context.Book
                    .Include(b => b.Publisher)
                    .ToListAsync();
            }
        if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        
        }

    }
}
