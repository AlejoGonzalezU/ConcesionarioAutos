using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable // Para deshabilitar alerta no necesaria sobre variables nullables que aparece en Visual Studio Mac

namespace ConcesionarioAutos.DAL.Entities
{
    public class Conversation : Entity
    {
        public int IdCliente { get; set; }

        public int IdEmpleado { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime StartDate { get; set; }

        // Este campo se define como nullable para que se pueda crear el registro sin que se deba poner una fecha de finalización
        [Display(Name = "Fecha de fin")]
        public DateTime? EndDate { get; set; }

        // Con estos DataAnnotations se crean relaciones entre tablas para agregar las foreign keys
        [ForeignKey("IdCliente")]
        public virtual Client Client { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual User Employee { get; set; }
    }
}

#nullable restore // Para habilitar de nuevo alerta no necesaria sobre variables nullables
