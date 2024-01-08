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
        public IActionResult OnGet()
        {
            starter = db.tbl_starter.ToList();
            var flag = HttpContext.Session.GetString("flag");
            if (flag != "true")
            {
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }

        }
    }
}
