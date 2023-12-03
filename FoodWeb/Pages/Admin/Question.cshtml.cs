using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class QuestionModel : PageModel
    {
        AppDbContext db;
        public Question question { get; set; }
        public QuestionModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Question question)
        {
            db.tbl_question.Add(question);
            db.SaveChanges();
            return RedirectToPage("ShowQuestion");

        }
    }
}
