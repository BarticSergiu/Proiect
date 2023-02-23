using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ProiectContext : DbContext
    {
        public ProiectContext (DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect.Models.Persoana> Persoana { get; set; } = default!;

        public DbSet<Proiect.Models.Sarcina> Sarcina { get; set; }

        public DbSet<Proiect.Models.Pontaj> Pontaj { get; set; }
    }
}
