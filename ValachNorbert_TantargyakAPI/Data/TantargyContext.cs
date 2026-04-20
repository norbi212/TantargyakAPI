using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ValachNorbert_TantargyakAPI.Models;

namespace ValachNorbert_TantargyakAPI.Data
{
    public class TantargyContext : DbContext
    {
        public TantargyContext(DbContextOptions<TantargyContext> options) : base(options)
        {
        }
        public DbSet<Tanar> Tanarok { get; set; } = null!;
        public DbSet<Tantargy> Tantargyak { get; set; } = null!;
    }
}
