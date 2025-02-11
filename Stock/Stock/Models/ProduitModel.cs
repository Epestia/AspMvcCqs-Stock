using System.ComponentModel.DataAnnotations;

namespace Stock.Models
{
    public class ProduitModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string Nom  { get; set; } = string.Empty;

        [StringLength(100)]
        public string Marque { get; set; }

        [StringLength(10)]
        public string GTIN { get; set; }

        [Required]
        [StringLength(100)]
        public string Prix { get; set; }
    }
}
