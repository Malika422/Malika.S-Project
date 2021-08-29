using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    class Drug
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public DrugType Type { get; set; }
        public int Id { get; }
        private static int _id = 0;

        public Drug()
        {
            _id++;
            Id = _id;
        }
        public Drug(string name, int count, DrugType type, double price) : this()
        {
            Name = name;
            Count = count;
            Type = type;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} {Price} {Count}";
        }
    }
}
