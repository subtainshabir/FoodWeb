using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace FoodWeb.Pages
{
    public class ShowIntroModel : PageModel
    {
        AppDbContext db;
        public Introduction intro { get; set; }
        public ShowIntroModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            intro = db.tbl_intro.FirstOrDefault();
        }
    }
}
