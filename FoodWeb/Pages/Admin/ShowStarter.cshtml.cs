using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowStarterModel : PageModel
    {
        public List<Starter> starter { get; set; }
        AppDbContext db;

        public ShowStarterModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
            starter = db.tbl_starter.ToList();

        }
    }
}
