using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddIntroModel : PageModel
    {
        AppDbContext db;
        public Introduction intro { get; set; }
        public AddIntroModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
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
        public IActionResult OnPost(Introduction intro)
        {
            db.tbl_intro.Add(intro);
            db.SaveChanges();
            return RedirectToPage("ShowIntro");
          
        }

    }
}
