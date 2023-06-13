using Microsoft.EntityFrameworkCore;
using DevIO.App.ViewModels;

namespace DevIO.App.Data
{
    public class MeuContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=YourServer; Database=YourDb; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=True");
            }
        }
        public DbSet<DevIO.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
    }
}
