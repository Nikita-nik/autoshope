using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.Models
{
    public class Car
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; } //idшник авто

        [DisplayName("Марка автомобиля")]
        public string NameCar { get; set; } //марка авто

        [DisplayName("Краткое описание")]
        public string ShortDesc { get; set; }//краткое опписание

        [DisplayName("Полное описание")]
        public string LongDesc { get; set; }//полное описание

        public string Img { get; set; }//картинка

        [DisplayName("Цена")]
        public uint Price { get; set; }//цена

        [DisplayName("Цвет автомобиля")]
        public string Color { get; set; }//цвет

        //public int CategoryId { get; set; }
        //[DisplayName("Категория автомобиля")]
        public Category Category { get; set; }//ссылка на категорию
        public List<MachineOrder> MachineOrders { get; set; }
        public Car()
        {
            MachineOrders = new List<MachineOrder>();
        }
        //можно сделать есть ли в налии
        //public int categoryId { set; get; }//idшник категории авто к которой оно относиться
        // public virtual Category Category { set; get; }
    }
}
