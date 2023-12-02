using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowBreakfastModel : PageModel
    {
        AppDbContext db;
        public List<BreakFast> breakfast { get; set; }
        public ShowBreakfastModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
            breakfast = db.tbl_breakfast.ToList();
        }
    }
}
