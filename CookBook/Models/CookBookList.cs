using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public class CookBookList
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
