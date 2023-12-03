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
        public void OnGet()
        {
        }
        public IActionResult OnPost(Introduction intro)
        {
            db.tbl_intro.Add(intro);
            db.SaveChanges();
            return RedirectToPage("ShowIntro");
          
        }

    }
}
