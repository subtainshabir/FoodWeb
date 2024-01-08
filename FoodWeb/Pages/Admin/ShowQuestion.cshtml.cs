using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowQuestionModel : PageModel
    {
        AppDbContext db;
        public Question question { get; set; }
        public ShowQuestionModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            question = db.tbl_question.FirstOrDefault();
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
