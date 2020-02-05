using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.Models
{
    public class Person : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<MachineOrder> MachineOrders { get; set; }
        public Person()
        {
            MachineOrders = new List<MachineOrder>();
        }
    }
}
