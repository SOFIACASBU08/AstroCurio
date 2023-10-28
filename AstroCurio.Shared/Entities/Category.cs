using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace AstroCurio.Shared.Entities
{
    public class Category
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [JsonIgnore]
        ICollection<Article> articles { get; set; }

        [JsonIgnore]
        ICollection<Link> Links { get; set; }
        
        [JsonIgnore]
        ICollection<Photography> Photographies { get; set; }
    }

}
