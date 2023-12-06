using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateDinnerModel : PageModel
    {
        public Dinner dinner { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;
        public UpdateDinnerModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;

        }
        
            
            public void OnGet(int id)
        {
            var itemtoupdate = db.tbl_dinner.Find(id);
            dinner = itemtoupdate;
        }
        public IActionResult OnPost(Dinner dinner)
        {
            if (dinner.Phote != null)
            {
                var Imagename = dinner.Phote.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "menu_images", "dinner");
                var ImagePath = Path.Combine(FolderPath, Imagename);

                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                dinner.Phote.CopyTo(fs);
                fs.Dispose();

                dinner.Image = Imagename;
                db.tbl_dinner.Update(dinner);
                db.SaveChanges();
                return Redirect($"UpdateDinner?id={dinner.id}");
            }
            else
            {
                db.tbl_dinner.Update(dinner);
                db.SaveChanges();
                return Redirect($"UpdateDinner?id={dinner.id}");
            }

        }
    }
}
