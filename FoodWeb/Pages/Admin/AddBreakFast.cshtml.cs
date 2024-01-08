using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddBreakFastModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public BreakFast breakFast { get; set; }
        public AddBreakFastModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;

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
        public IActionResult OnPost(BreakFast breakFast)
        {
            string ImageName = breakFast.Photo.FileName.ToString();
            var Folderpath = Path.Combine(env.WebRootPath, "menu_images","breakfast");
            var ImagePath=Path.Combine(Folderpath, ImageName);

            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            breakFast.Photo.CopyTo(fs);
            fs.Dispose();

            breakFast.Image = ImageName;
            db.tbl_breakfast.Add(breakFast);
            db.SaveChanges();
            return RedirectToPage("ShowBreakfast");


        }
    }
}
