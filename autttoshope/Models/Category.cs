using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.Models
{
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }
    }
}
