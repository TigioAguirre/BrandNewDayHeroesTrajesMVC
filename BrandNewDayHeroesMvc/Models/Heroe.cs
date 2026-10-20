using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrandNewDayHeroesMvc.Models
{
    public class Heroe
    {
        [Key]
        public int HeroeId { get; set; }

        [Required]  
        public string NombreHeroe { get; set; }

        [Required]
        public string Alias { get; set; }

        public virtual ICollection<Traje> Trajes { get; set; }
    }

}
