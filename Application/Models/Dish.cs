using System.Linq;

namespace Application.Models
{
    /// <summary>
    /// Contains a dish by name and number of times the dish has been ordered
    /// </summary>
    public class Dish
    {
        public string DishName { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            if (Count > 1)
            {
                return DishName + "(x" + Count + ")";
            }

            return DishName;
        }

        public bool IsMultipleAllowed()
        {
            return Menu.AllowedDuplicates.Select(s => s.ToLower()).Contains(DishName.ToLower());
        }

    }
}