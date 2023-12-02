using FoodWeb.Model;
using Microsoft.EntityFrameworkCore;
namespace FoodWeb.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<AboutUs> tbl_about { get; set; }
        public DbSet<BreakFast> tbl_breakfast { get; set; }
        public DbSet<Chefs> tbl_chefs { get; set; }
        public DbSet<ContactUs> tbl_contact { get; set; }
        public DbSet<Dinner> tbl_dinner { get; set; }
        public DbSet<Facts> tbl_facts { get; set; }
        public DbSet<Gallary> tbl_gallay { get; set; }
        public DbSet<Introduction> tbl_intro { get; set; }
        public DbSet<Launch> tbl_launch { get; set; }
        public DbSet<Offers> tbl_offers { get; set; }
        public DbSet<Orders> tbl_orders { get; set; }
        public DbSet<Question> tbl_question { get; set; }
        public DbSet<Starter> tbl_starter { get; set; }
        public DbSet<Testimonial> tbl_testimonial { get; set; }


    }
}
