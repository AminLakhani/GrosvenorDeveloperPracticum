using System;
using System.Collections.Generic;
using System.Linq;
using Application.Models;

namespace Application
{
    public class Cook : ICook
    {
        public Dish MakeDish(int dishID, TimeOfDay timeOfDay)
        {
            Menu menu = new Menu(timeOfDay);
            return new Dish() { Count = 1, DishName = menu.Items[dishID] };
        }

    }
}