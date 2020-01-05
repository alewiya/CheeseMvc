using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMvc.Models
{
    public class CheeseData
    {
        static private List<Cheese> cheeses = new List<Cheese>();
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }
        public static void Add(Cheese newcheese)
        {
           cheeses.Add(newcheese);
        }
        //remove cheese ferom list
        public static void Remove(int id)
        {
            Cheese cheeseToRomve=GetById(id);
        }
        //getby id
        public static Cheese GetById(int id)
        {
            return cheeses.Single(x => x.CheeseId == id);
        }
        public static void Edit(Cheese editCheese)
        {
            cheeses.Add(editCheese);
        }
    }
    
}
