using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
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

        public byte[] Img { get; set; }//картинка

        [DisplayName("Цена")]
        public uint Price { get; set; }//цена

        [DisplayName("Цвет автомобиля")]
        public string Color { get; set; }//цвет
        [NotMapped]
        private IFormFile picture;
        [NotMapped]
        public IFormFile Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
                using (var binaryReader = new BinaryReader(value.OpenReadStream()))
                {
                    Img = binaryReader.ReadBytes((int)value.Length);
                }
            }
        }
        //public int CategoryId { get; set; }
        //[DisplayName("Категория автомобиля")]
        public Category Category { get; set; }//ссылка на категорию
        public int CategoryId { get; set; }//ссылка на категорию
        public bool OnSale { get; set; }
        public bool IsBestSeller { get; set; }
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
