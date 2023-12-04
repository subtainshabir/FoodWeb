using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateBreakfastModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public BreakFast breakfast { get; set; }
        public UpdateBreakfastModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void OnGet(int id)
        {
            var itemtoupdate = db.tbl_breakfast.Find(id);
            breakfast=itemtoupdate;
        }
        public IActionResult OnPost(BreakFast breakfast)
        {
            if (breakfast.Photo != null)
            {
                string ImageName = breakfast.Photo.FileName.ToString();
                var Folderpath = Path.Combine(env.WebRootPath, "menu_images", "breakfast");
                var ImagePath= Path.Combine(Folderpath, ImageName);

                var fs=new FileStream(ImagePath, FileMode.Create);
                breakfast.Photo.CopyTo(fs);

                breakfast.Image = ImageName;
                db.tbl_breakfast.Update(breakfast);
                db.SaveChanges();
                return Redirect($"UpdateBreakfast?id={breakfast.id}");
            }
            else
            {
                db.tbl_breakfast.Update(breakfast);
                db.SaveChanges();
                return Redirect($"UpdateBreakfast?id={breakfast.id}");
            }
        }
    }
}
