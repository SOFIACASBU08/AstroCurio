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
    public class Follow
    {
      
        public int Id { get; set; }

        [Display(Name = "Tipo de usuario")]
        public string Type { get; set; }



        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Estado { get; set; } = null!;

        //RELACIÓN FK

       // public int  PersonId { get; set; }

        //[JsonIgnore]

        //public Person Person { get; set; }

        //representa el usuario que sigue
        public int FollowerId { get; set; }
        [JsonIgnore]
        public Person Follower { get; set; }

        // FolloweeId representa el usuario que es seguido.
        public int FolloweeId { get; set; }
        [JsonIgnore]
        public Person Followee { get; set; }

        [JsonIgnore]
        ICollection<Person> People { get; set; }
    }
}
