using System.ComponentModel.DataAnnotations;

namespace FoodWeb.Model
{
    public class Orders
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required e.g Jhon")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Email is Required e.g example@gmail.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is Required e.g +92XXXXXXXXXX")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Name is Required e.g dd/mm/yy")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Name is Required e.g 11:00am")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Name is Required e.g 2 or 3 etc.")]
        public string no_of_people { get; set; }
        [Required(ErrorMessage = "Write anything.")]
        public string Message { get; set; }
    }
}
