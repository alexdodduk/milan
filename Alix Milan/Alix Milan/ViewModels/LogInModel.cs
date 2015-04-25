using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Alix_Milan.Models
{
    public class LogInModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue=false)]
        public string ReturnUrl { get; set; }
    }
}