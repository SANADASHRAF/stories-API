using Microsoft.EntityFrameworkCore;

namespace storiessapi.Model
{
    public class stdbcontextr:DbContext
    {


       public stdbcontextr(DbContextOptions<stdbcontextr>options):base(options)   
        {

        }
       

        public DbSet<Category> categories { get; set; }
        public DbSet<story> stories { get; set; }
    }
}
