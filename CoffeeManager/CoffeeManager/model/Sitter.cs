using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.model
{
    public class Sitter
    {
        private int id;
        private string name;
        private string status;

        public Sitter(int id, string name, string status)
        {
            this.id = id;
            this.name = name;
            this.status = status;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
