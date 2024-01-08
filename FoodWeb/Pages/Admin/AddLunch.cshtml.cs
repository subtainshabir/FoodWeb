using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddLunchModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Launch launch { get; set; }
        public AddLunchModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db=db;
            this.env=env;
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
        public void OnPost(Launch launch)
        {
            var ImageName = launch.Photo.FileName.ToString();
            var FolderName = Path.Combine(env.WebRootPath, "menu_images", "Lunch");
            var ImageFolder = Path.Combine(FolderName, ImageName);

            FileStream fs= new FileStream(ImageFolder, FileMode.Create);
            launch.Photo.CopyTo(fs);
            fs.Dispose();

            launch.Image = ImageName;
            db.tbl_launch.Add(launch);
            db.SaveChanges();

        }
    }

}
