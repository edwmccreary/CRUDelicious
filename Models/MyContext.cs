using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        //the dishes table will come from this variable
        public DbSet<Dish> Dishes {get;set;}
    }
}