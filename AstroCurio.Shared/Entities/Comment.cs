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
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Link ID")]
        public int LinkId { get; set; }

        [Display(Name = "Article ID")]
        public int ArticleId { get; set; }

        [Display(Name = "Photography ID")]
        public int PhotographyId { get; set; }

        [Display(Name = "Fecha de Comentario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha_comen { get; set; }

        [Display(Name = "Contenido")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Contenido { get; set; } = null!;

        //RELACION FK
        [JsonIgnore]

        [ForeignKey("LinkId")]
        public Link Link { get; set; }

        [JsonIgnore]

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        [JsonIgnore]

        [ForeignKey("PhotographyId")]
        public Photography Photography { get; set; }

        [JsonIgnore]
        ICollection<Article> Articles { get; set; }

        [JsonIgnore]
        ICollection<Link> Links { get; set; }

        [JsonIgnore]
        ICollection<Photography> photographies { get; set; }



    }
}
