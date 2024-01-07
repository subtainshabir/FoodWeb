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
        public void OnGet()
        {
            about = db.tbl_about.FirstOrDefault();
        }
    }
}
