using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowAboutModel : PageModel
    {

        AppDbContext db;
        public AboutUs about { get; set; }
        public ShowAboutModel(AppDbContext db)
        {
            this.db= db;
        }
        public IActionResult OnGet()
        {
            about = db.tbl_about.FirstOrDefault();
            var result = HttpContext.Session.GetString("flag");
            if (result != "true")
            {
                return RedirectToPage("index");
            }
            else
            {
                return Page();
            }
        }
    }
}
