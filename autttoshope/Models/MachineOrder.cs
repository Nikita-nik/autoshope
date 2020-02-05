using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.Models
{
    public class MachineOrder
    {

        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Пользователь")]
        public Person Person { get; set; }

        [DisplayName("Автомобиль")]//посмотреть подумать пример другой
        public Car Car { get; set; }

        [DisplayName("Телефон")]
        public string Phone { get; set; }

        public int CarId { get; set; }
        public Category Category { get; set; }
    }
}
