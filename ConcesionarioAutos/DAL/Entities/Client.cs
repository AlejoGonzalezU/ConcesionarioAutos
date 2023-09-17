using System.ComponentModel.DataAnnotations;

#nullable disable // Para deshabilitar alerta no necesaria sobre variables nullables que aparece en Visual Studio Mac

namespace ConcesionarioAutos.DAL.Entities
{
    public class Client : Entity
	{
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]    
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PhoneNumber { get; set; }
    }
}

#nullable restore // Para habilitar de nuevo alerta no necesaria sobre variables nullables
