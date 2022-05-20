using AznToCurrencyApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AznToCurrencyApi.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { }
        public DbSet<CbarLog> CbarLogs { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
