using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pry_ventas_ds505.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "Escriba número de ID")]
        [Display(Name = "Id del Cliente")]
        public int ID_Cliente { get; set; }

        [Required(ErrorMessage = "Escriba el Nombre")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba apellido")]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Escriba una Dirección")]
        [StringLength(100)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Escriba un Correo Electrónico")]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Escriba un Teléfono")]
        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
    }
}
