using System.ComponentModel.DataAnnotations;

#nullable disable // Para deshabilitar alerta no necesaria sobre variables nullables que aparece en Visual Studio Mac

namespace ConcesionarioAutos.DAL.Entities
{
    public class Entity
	{
		[Key]
        [Required]
        public string Id { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Fecha de modificación")]
        public DateTime ModifiedDate { get; set; }
    }
}

#nullable restore // Para habilitar de nuevo alerta no necesaria sobre variables nullables
