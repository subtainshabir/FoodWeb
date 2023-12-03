using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateIntroModel : PageModel
    {
        public Introduction intro { get; set; }
        AppDbContext db;
        public UpdateIntroModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet(int id)
        {
            var itemtoupdate=db.tbl_intro.Find(id);
            intro = itemtoupdate;
        }
        public IActionResult OnPost(Introduction intro)
        {
            db.tbl_intro.Update(intro);
            db.SaveChanges();
            return RedirectToPage("ShowIntro");

        }
    }

}
