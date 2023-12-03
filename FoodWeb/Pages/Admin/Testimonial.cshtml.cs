using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class TestimonialModel : PageModel
    {
        public Testimonial testimonial { get; set; }
        IWebHostEnvironment env;
        AppDbContext db;
        public TestimonialModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;

        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Testimonial testimonial)
        {
            var ImageName = testimonial.Photo.FileName.ToString();
            var FolderName = Path.Combine(env.WebRootPath, "testimonial");
            var ImagePath=Path.Combine(FolderName, ImageName);  

            FileStream fs=new FileStream(ImagePath, FileMode.Create);
            testimonial.Photo.CopyTo(fs);
            fs.Dispose();

            testimonial.Image = ImageName;
            db.tbl_testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToPage("ShowTestimonial");


        }

    }
}
