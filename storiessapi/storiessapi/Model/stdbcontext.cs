using Microsoft.EntityFrameworkCore;

namespace storiessapi.Model
{
    public class stdbcontextr:DbContext
    {


       public stdbcontextr()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=storiesAPI;Data Source=.");
        }

        public DbSet<Category> categories { get; set; }
    }
}
