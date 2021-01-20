using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models {
    public class Bookmod {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public string Author { get; set; }
    }
}