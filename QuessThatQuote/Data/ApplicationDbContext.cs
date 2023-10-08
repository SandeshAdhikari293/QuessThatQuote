using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuessThatQuote.Models;

namespace QuessThatQuote.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<QuessThatQuote.Models.LeaderboardEntry> LeaderboardEntry { get; set; } = default!;
    }
}
