using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DTO.Models
{
    public class CustomerDisplayModel
    {
        public CustomerDisplayModel()
        { }
        public CustomerDisplayModel(string name, string address, int id = 0)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
