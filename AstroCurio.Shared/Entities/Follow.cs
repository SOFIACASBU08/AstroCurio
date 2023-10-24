using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstroCurio.Shared.Entities
{
    public class Follow
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Seguidor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string User_SeguidorId { get; set; }

        [Display(Name = "Seguido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string User_SeguidoId { get; set; }

        [Display(Name = "Notificación")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Notificación { get; set; } = null!;

        //RELACIÓN FK

        [ForeignKey("UserId")]
        public User User_Seguido { get; set; }

       
    }
}
