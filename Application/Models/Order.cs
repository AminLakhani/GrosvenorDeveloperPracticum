using System.Collections.Generic;
using System.Linq;

namespace Application.Models
{
    public enum TimeOfDay
    {
        Morning = 1,
        Evening = 2
    }

    public class Order
    {
        public Order()
        {
            Dishes = new List<Dish>();
        }
        public TimeOfDay TimeOfDay { get; set; }
        public List<Dish> Dishes { get; set; }

        public override string ToString()
        {
            return string.Join(',', Dishes.Select(s => s.ToString()));
        }

        public void AddDish(Dish d)
        {
            var existingOrder = Dishes.SingleOrDefault(x => x.DishName.Equals(d.DishName, System.StringComparison.InvariantCultureIgnoreCase));
            if (existingOrder == null)
            {
                Dishes.Add(d);
            }
            else
            {
                existingOrder.Count++;
            }

        }

        public bool ContainsDish(Dish d)
        {
            return Dishes.Select(s => s.DishName.ToLower()).Contains(d.DishName.ToLower());
        }

    }
}