using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pry_ventas_ds505.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        [Required(ErrorMessage = "Escriba el número de ID")]
        [Display(Name = "ID del Empleado")]
        public int ID_Empleado { get; set; }

        [Required(ErrorMessage = "Escriba el Nombre")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba el Apellido")]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Escriba el Cargo")]
        [StringLength(50)]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Escriba el Salario")]
        [Display(Name = "Salario")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de contratación")]
        [Display(Name = "Fecha de Contratación")]
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }
    }
}
