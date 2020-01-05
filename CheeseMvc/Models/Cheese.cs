using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMvc.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CheeseId { get; set; }
        public CheeseType Type { get; set; }
        public int Rating { get;set; }
        private static int nextId = 1;
        public Cheese() {
            CheeseId = nextId;
            nextId++;
        }
        
    }
}
