using System.ComponentModel.DataAnnotations;

namespace FoodWeb.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="UserName is Required. ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "PassKey is Required. ")]
        public string PassKey { get; set; }
    }
}
