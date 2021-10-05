using System.Collections.Generic;
using Application.Models;

namespace Application
{

    public interface ICook
    {
        /// <summary>
        /// Constructs a list of dishes, each dish with a name and a count
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Dish MakeDish(int dishID, TimeOfDay timeOfDay);
    }
}