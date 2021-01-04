using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.model
{
    public class Drink
    {
        int id;
        string name;
        int idDrinkType;
        float cost;

        public float Cost { get => cost; set => cost = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdDrinkType { get => idDrinkType; set => idDrinkType = value; }

        public Drink(int id, string name, int idDrinkType, float cost)
        {
            this.id = id;
            this.name = name;
            this.idDrinkType = idDrinkType;
            this.cost = cost;
        }
    }
}
