using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable // Para deshabilitar alerta no necesaria sobre variables nullables que aparece en Visual Studio Mac

namespace ConcesionarioAutos.DAL.Entities
{
    public class Message : Entity
    {
        public string IdConversacion { get; set; }

        [Display(Name = "Autor")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Author { get; set; }

        [Display(Name = "Mensaje")]
        [MaxLength(10000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string MessageSent { get; set; }

        [Display(Name = "Fecha de envío")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime SentDate { get; set; }

        // Con estos DataAnnotations se crean relaciones entre tablas para agregar las foreign keys
        [ForeignKey("IdConversacion")]
        public virtual Conversation ConversationKey { get; set; }
    }
}

#nullable restore // Para habilitar de nuevo alerta no necesaria sobre variables nullables
