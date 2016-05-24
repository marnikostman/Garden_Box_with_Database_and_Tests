using System;
using GardenBoxNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckPerimeter()
        {
            GardenBox box = new GardenBox(1, 2, "carrots", 1.0m);
            int expected = 6;
            int actual = box.perimeter;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckArea()
        {
            GardenBox box = new GardenBox(1, 2, "carrots", 1.0m);
            int expected = 2;
            int actual = box.area;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckOneCarrot()
        {
            GardenBox box = new GardenBox(1, 1, "carrots", 16.0m / 16.0m);
            int expected = 1;
            int actual = box.numberVegetable;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckZeroCarrots()
        {
            GardenBox box = new GardenBox(0, 0, "carrots", 16.0m / 16.0m);
            int expected = 0;
            int actual = box.numberVegetable;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckNumberCarrots()
        {
            GardenBox box = new GardenBox(4, 4, "carrots", 16.0m / 16.0m);
            int expected = 16;
            int actual = box.numberVegetable;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckNumberBeets()
        {
            GardenBox box = new GardenBox(4, 4, "beets", 9.0m / 16.0m);
            int expected = 9;
            int actual = box.numberVegetable;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckNumberCorn()
        {
            GardenBox box = new GardenBox(4, 4, "corn", 3.0m / 16.0m);
            int expected = 3;
            int actual = box.numberVegetable;
            Assert.AreEqual(expected, actual);
        }
    }
}
