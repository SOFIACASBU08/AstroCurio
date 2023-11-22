﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AstroCurio.Shared.Entities
{
    public class Link
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Titulo { get; set; } = null!;

        [Display(Name = "URL")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Url { get; set; } = null!;

        [Display(Name = "Fecha de Publicación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha_publi { get; set; }

        //RELACONES Fk

        public int PersonId { get; set; }

        [JsonIgnore]

        public Person Person { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]

        public Category Category { get; set; }

        
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}