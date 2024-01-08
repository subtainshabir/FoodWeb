using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddChefModel : PageModel
    {
        AppDbContext db;
        public Chefs chef { get; set; }
        IWebHostEnvironment env;
        public AddChefModel(AppDbContext db, IWebHostEnvironment env)
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
        public void OnPost(Chefs chef)
        {
            var ImageName = chef.Photo.FileName.ToString();
            var FolderPath = Path.Combine(env.WebRootPath, "chefs");
            var ImagePath=Path.Combine(FolderPath, ImageName);

            FileStream fs=new FileStream(ImagePath,FileMode.Create);
            chef.Photo.CopyTo(fs);
            fs.Dispose();

            chef.Image = ImageName;
            db.tbl_chefs.Add(chef);
            db.SaveChanges();
        }
    }
}
