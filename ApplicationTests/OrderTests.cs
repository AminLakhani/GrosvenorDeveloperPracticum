using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Application.Models;

namespace ApplicationTests
{

    [TestFixture]
    public class OrderTests
    {

        private Dish _dish;
        private Order order;

        [SetUp]
        public void Setup()
        {
            _dish = new Dish();
            order = new Order();
        }

        [Test]
        public void OrderAddDish_AddDishToEmptyOrder_ReturnTrue()
        {
            order.AddDish(_dish);
            Assert.Greater(order.Dishes.Count, 0);
        }

        [Test]
        public void OrderAddDish_AddDishToExistingOrder_ReturnTrue()
        {
            _dish.DishName = "test";
            order.AddDish(_dish);

            _dish = new Dish();
            _dish.DishName = "test2";
            order.AddDish(_dish);
            Assert.Greater(order.Dishes.Count, 1);
        }

        public void OrderAddDish_AddDishToExistingOrderWithDplicate_ReturnTrue()
        {
            _dish.DishName = "test";
            order.AddDish(_dish);
            order.AddDish(_dish);
            Assert.Greater(order.Dishes.First().Count, 1);
        }

        [Test]
        public void ContainsDish_DoesContain_ReturnTrue()
        {
            _dish.DishName = "test";
            order.AddDish(_dish);
            Assert.IsTrue(order.ContainsDish(_dish));

        }

        [Test]
        public void ContainsDish_DoesNotContain_ReturnFalse()
        {
            _dish.DishName = "test";
            order.AddDish(_dish);

            _dish = new Dish();
            _dish.DishName = "test2";

            Assert.IsFalse(order.ContainsDish(_dish));

        }

    }
}
