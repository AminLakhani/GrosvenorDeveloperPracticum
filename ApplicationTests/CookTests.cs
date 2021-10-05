using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Application.Models;
using Application;

namespace ApplicationTests
{
    [TestFixture]
    public class CookTests
    {
        private ICook cook;

        [SetUp]
        public void Setup()
        {
            cook = new Cook();
        }

        [Test]
        [TestCase(1, TimeOfDay.Evening, "steak")]
        [TestCase(2, TimeOfDay.Evening, "potato")]
        [TestCase(3, TimeOfDay.Evening, "wine")]
        [TestCase(4, TimeOfDay.Evening, "cake")]
        [TestCase(1, TimeOfDay.Morning, "egg")]
        [TestCase(2, TimeOfDay.Morning, "toast")]
        [TestCase(3, TimeOfDay.Morning, "coffee")]
        public void MakeDish_AddedCorrectDish_ReturnTrue(int dishId, TimeOfDay tod, string expected)
        {
            var dish = cook.MakeDish(dishId, tod);
            Assert.AreEqual(dish.DishName, expected);
        }

        [Test]
        [TestCase(4, TimeOfDay.Morning)]
        public void MakeDish_NoDessertInMorning_ThrowException(int dishId, TimeOfDay tod)
        {
            Assert.Throws<KeyNotFoundException>(() => cook.MakeDish(dishId, tod));

        }

    }
}
