using System.ComponentModel.DataAnnotations;

namespace Stock.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Email invalide")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
    }
}
