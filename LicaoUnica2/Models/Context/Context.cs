using LicaoUnica2.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LiçãoUnica2.Models.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option)
        {
            Database.EnsureCreated();
        }


        public DbSet<Usuario> Usuario { get; set; }
    }


}
