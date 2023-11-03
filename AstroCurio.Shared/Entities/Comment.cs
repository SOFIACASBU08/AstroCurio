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
    public class Comment
    {
       
        public int Id { get; set; }

        [Display(Name = "Fecha de Comentario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha_comen { get; set; }

        [Display(Name = "Contenido")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Contenido { get; set; } = null!;

        //RELACION FK
        public int? LinkId { get; set; }
        [JsonIgnore]
        public Link Link { get; set; }

        public int? ArticleId { get; set; }
        [JsonIgnore]
        public Article Article { get; set; }


        public int? PhotographyId { get; set; }
        [JsonIgnore]
        public Photography Photography { get; set; }
        
       
        



    }
}
