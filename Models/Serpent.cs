using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace myown.Models
{
    public class Serpent
    {
        public int Id { get; set; }
        [Display(Name = "Nome Popular")]
        public string? PopularName { get; set; }
        [Display(Name = "Nome Científico")]
        public string? CientificName { get; set; }
        [Display(Name = "Família")]
        public Family FamilyType { get; set; }
    }
}