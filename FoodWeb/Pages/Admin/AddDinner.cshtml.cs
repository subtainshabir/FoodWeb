using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddDinnerModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Dinner dinner { get; set; }
        public AddDinnerModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db=db;
            this.env=env;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Dinner dinner)
        {
            var ImageName = dinner.Phote.FileName.ToString();
            var FolderPath = Path.Combine(env.WebRootPath, "menu_images", "dinner");
            var ImagePath=Path.Combine(FolderPath, ImageName);

            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            dinner.Phote.CopyTo(fs);
            fs.Dispose();

            dinner.Image = ImageName;
            db.tbl_dinner.Add(dinner);
            db.SaveChanges();
            return RedirectToPage("ShowDinner");
        }
    }
}
