using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AstroCurio.Shared.Entities
{
    public class Article
    {
        [Key]
        [Display(Name = "Id")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Id { get; set; }


        [Display(Name = "Id")]
        public string UserId { get; set; } = null!;

        [Display(Name = "Título")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Titulo { get; set; } = null!;

        [Display(Name = "Contenido")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Contenido { get; set; } = null!;

        [Display(Name = "Fecha de Publicación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha_publi { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CategoryId { get; set; }


        //propiedades para la relación
        //FK

        [JsonIgnore]
        [ForeignKey("UserId")]
        public User User { get; set; }

       
        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }





    }
}
