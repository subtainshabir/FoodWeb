using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowLunchModel : PageModel
    {
        AppDbContext db;
        public List<Launch> launch { get; set; }
        public ShowLunchModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            launch=db.tbl_launch.ToList();
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
