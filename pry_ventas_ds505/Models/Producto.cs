using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pry_ventas_ds505.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        [Required(ErrorMessage = "Escriba el ID del Producto")]
        [Display(Name = "ID del Producto")]
        public int ID_Producto { get; set; }

        [Required(ErrorMessage = "Escriba el Nombre del Producto")]
        [StringLength(100)]
        [Display(Name = "Nombre del Producto")]
        public string NombreProducto { get; set; }

        [StringLength(255)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Escriba el Precio del Producto")]
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Escriba el Stock del Producto")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}
