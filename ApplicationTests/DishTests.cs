using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Application.Models;

namespace ApplicationTests
{
    [TestFixture]
    public class DishTests
    {
        private Dish _dish;

        [SetUp]
        public void Setup()
        {
            _dish = new Dish();
        }

        [Test]
        [TestCase("coffee")]
        [TestCase("potato")]
        public void IsMultipleAllowed_AreAllowed_ReturnTrue(string dishName)
        {
            _dish.DishName = dishName;
            Assert.IsTrue(_dish.IsMultipleAllowed());
        }


        [Test]
        [TestCase("steak")]
        [TestCase("toast")]
        [TestCase("egg")]
        [TestCase("wine")]
        [TestCase("cake")]
        [TestCase("")]
        [TestCase("poop")]
        public void IsMultipleAllowed_AreNotAllowed_ReturnFalse(string dishName)
        {
            _dish.DishName = dishName;
            Assert.IsFalse(_dish.IsMultipleAllowed());
        }
    }
}
