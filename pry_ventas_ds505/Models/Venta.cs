using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pry_ventas_ds505.Models
{
    [Table("Ventas")]
    public class Venta
    {
        [Key]
        [Required(ErrorMessage = "Ingrese el ID de la venta")]
        [Display(Name = "ID de Venta")]
        public int ID_Venta { get; set; }

        [Required(ErrorMessage = "Ingrese el ID del cliente")]
        [Display(Name = "ID de Cliente")]
        public int ID_Cliente { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de la venta")]
        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }

        [Required(ErrorMessage = "Ingrese el total de la venta")]
        [Display(Name = "Total de Venta")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalVenta { get; set; }

        [Required(ErrorMessage = "Ingrese el método de pago")]
        [Display(Name = "Método de Pago")]
        [StringLength(50)]
        public string MetodoPago { get; set; }
    }
}
