using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateTestimonialModel : PageModel
    {
        public Testimonial testimonial { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;
        public UpdateTestimonialModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env=env;
        }
        public void OnGet(int id)
        {
            var itemtoupdate = db.tbl_testimonial.Find(id);
            testimonial = itemtoupdate;
        }
        public IActionResult OnPost(Testimonial testimonial)
        {
            if (testimonial.Photo != null)
            {
                var Imagename = testimonial.Photo.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "testimonial");
                var ImagePath = Path.Combine(FolderPath, Imagename);

                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                testimonial.Photo.CopyTo(fs);
                fs.Dispose();

                testimonial.Image = Imagename;
                db.tbl_testimonial.Update(testimonial);
                db.SaveChanges();
                return Redirect($"UpdateTestimonial?id={testimonial.id}");
            }
            else
            {
                db.tbl_testimonial.Update(testimonial);
                db.SaveChanges();
                return Redirect($"UpdateTestimonial?id={testimonial.id}");
            }
        }
    }
}
