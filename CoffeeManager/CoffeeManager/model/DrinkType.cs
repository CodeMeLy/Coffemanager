using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.model
{
    public class DrinkType
    {
        private int id;
        private string name;

        public DrinkType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
