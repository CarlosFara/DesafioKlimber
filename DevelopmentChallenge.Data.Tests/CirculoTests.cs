using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class CirculoTests
    {
        [TestCase]
        public void TestResumenAreaDeUnCirculo()
        {
            var circulo = new Circulo(5);

            decimal result = System.Math.Round(circulo.CalcularArea(), 2);

            Assert.AreEqual(78.54m, result);
        }

        [TestCase]
        public void TestResumenAreaDeMasCirculos()
        {
            var circulos = new List<IFormaGeometrica> {
                new Circulo(5),
                new Circulo(2)
            };

            decimal result = circulos.Sum(c => System.Math.Round(c.CalcularArea(), 2));

            Assert.AreEqual(91.11m, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeUnCirculo()
        {
            var circulo = new Circulo(5);

            decimal result = System.Math.Round(circulo.CalcularPerimetro(), 2);

            Assert.AreEqual(15.71m, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeMasCirculos()
        {
            var circulos = new List<IFormaGeometrica> {
                new Circulo(5),
                new Circulo(2)
            };

            decimal result = circulos.Sum(c => System.Math.Round(c.CalcularPerimetro(), 2));

            Assert.AreEqual(21.99m, result);
        }
    }
}
