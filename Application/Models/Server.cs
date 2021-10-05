using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Models
{
    public class Server : IServer
    {
        private readonly ICook _cook;

        public Server(ICook cook = null)
        {
            _cook = cook ?? new Cook();
        }

        public string TakeOrder(string unparsedOrder)
        {

            if (String.IsNullOrWhiteSpace(unparsedOrder))
            {
                return "error";
            }

            try
            {
                Order order = MakeOrder(unparsedOrder);
                if (order.Dishes.Count == 0) 
                {
                    return "error";
                }

                return order.ToString();
            }
            catch (ApplicationException)
            {
                return "error";
            }
        }


        private Order MakeOrder(string unparsedOrder)
        {
			var options = unparsedOrder.Split(',');
			string timeOfDay = options.First().Trim().ToLower();

			if (!timeOfDay.Equals("morning", StringComparison.InvariantCultureIgnoreCase) && !timeOfDay.Equals("evening", StringComparison.InvariantCultureIgnoreCase))
			{
				throw new ApplicationException("error");
			}

			var dishIDs = options.Skip(1).ToList()
			 .Where(v=> !String.IsNullOrWhiteSpace(v) )
			 .Select(s => Convert.ToInt32(s.Trim()))
			 .OrderBy(o => o)
			 .ToList();

			var order = new Order() { TimeOfDay = timeOfDay == "morning" ? TimeOfDay.Morning : TimeOfDay.Evening };
			foreach (int i in dishIDs)
			{
				if (order.TimeOfDay == TimeOfDay.Morning && i == 4)
				{
					throw new ApplicationException("error");
				}

				var dish = _cook.MakeDish(i, order.TimeOfDay);

				if (!order.ContainsDish(dish) || dish.IsMultipleAllowed())
				{
					order.AddDish(dish);
				}
				else
				{
					throw new ApplicationException("error");
				}

			}

			return order;
        }
    }
}
