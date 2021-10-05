using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class Menu
    {
        public Dictionary<int, string> Items { get; }

        public static List<string> AllowedDuplicates { get { return new List<string>() { "potato", "coffee" }; } }

        private Dictionary<int, string> MorningMenu;

        private Dictionary<int, string> EveningMenu;

        public Menu(TimeOfDay timeOfDay) 
        {
            MorningMenu = new Dictionary<int, string>();
            MorningMenu.Add(1, "egg");
            MorningMenu.Add(2, "toast");
            MorningMenu.Add(3, "coffee");

            EveningMenu = new Dictionary<int, string>();
            EveningMenu.Add(1, "steak");
            EveningMenu.Add(2, "potato");
            EveningMenu.Add(3, "wine");
            EveningMenu.Add(4, "cake");

            if (timeOfDay == TimeOfDay.Morning)
            {
                Items = MorningMenu;
            }
            else 
            {
                Items = EveningMenu;
            }
        }


    }

}
