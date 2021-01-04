using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.model
{
    public class Bill
    {
        private string id;
        private int idSitter;
        private string status;

        public Bill(string id, int idSitter, string status)
        {
            this.Id = id;
            this.idSitter = idSitter;
            this.Status = status;
        }

        public string Id { get => id; set => id = value; }
        public int IdSitter { get => idSitter; set => idSitter = value; }
        public string Status { get => status; set => status = value; }
    }
}
