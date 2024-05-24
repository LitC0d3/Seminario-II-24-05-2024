using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pry_ventas_ds505.Models
{
    [Table("tb_categoria")]
    public class Categoria
    {
        [Key]
        [Required(ErrorMessage = "Ingrese el código de la categoría")]
        [StringLength(5)]
        [Display(Name = "Código de Categoría")]
        public string codigo_categoria { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la categoría")]
        [StringLength(30)]
        [Display(Name = "Categoría")]
        public string categoria { get; set; }
    }
}
