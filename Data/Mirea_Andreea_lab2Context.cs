using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mirea_Andreea_lab2.Models;

namespace Mirea_Andreea_lab2.Data
{
    public class Mirea_Andreea_lab2Context : DbContext
    {
        public Mirea_Andreea_lab2Context (DbContextOptions<Mirea_Andreea_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Mirea_Andreea_lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Mirea_Andreea_lab2.Models.Publisher> Publisher { get; set; }
    }
}
