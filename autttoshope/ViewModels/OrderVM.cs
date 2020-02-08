using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        public string NameCar { get; set; } //марка авто
       
        public string Color { get; set; }//цвет

        public int CategoryId { get; set; }

        public string Phone { get; set; }

    }
}
