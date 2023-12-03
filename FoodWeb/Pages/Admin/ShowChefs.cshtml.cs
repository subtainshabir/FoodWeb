using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowChefsModel : PageModel
    {
        AppDbContext db;
        public List<Chefs> chef { get; set; }
        public ShowChefsModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
            chef = db.tbl_chefs.ToList();

        }
    }
}
