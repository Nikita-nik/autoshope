using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.Models
{
    public class ApplicationForTO
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Пользователь")]
        public Person Person { get; set; }

        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [DisplayName("Дата записи")]
        public DataType DateOfTO { get; set; }//дата записи на ТО

        [DisplayName("Автомобиль")]
        public string CarModel { get; set; }//какая машина приедет на ТО
    }
}
