using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class FactsModel : PageModel
    {
        AppDbContext db;
        public Facts fact { get; set; }
        public FactsModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
        }
        public void OnPost(Facts fact)
        {
            db.tbl_facts.Add(fact);
            db.SaveChanges();
        }
    }
}
