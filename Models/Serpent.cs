using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Serpent
    {
        public int Id { get; set; }
        public string? PopularName { get; set; }
        public string? CientificName { get; set; }
        public Family FamilyType { get; set; }
    }
}