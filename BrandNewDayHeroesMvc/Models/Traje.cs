using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrandNewDayHeroesMvc.Models
{
    public class Traje
    {
        [Key]
        public int TrajeId { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Heroe> Heroes { get; set; }
    }
}