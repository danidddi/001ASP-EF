using Microsoft.EntityFrameworkCore;

namespace ASPwithEF.Models
{
    // контекст отображения на базу данных
    public class ApplicationContext: DbContext
    {
        public DbSet<Edition> Editions { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // создание БД если ее нет
            Database.EnsureCreated();
        }
    }
}
