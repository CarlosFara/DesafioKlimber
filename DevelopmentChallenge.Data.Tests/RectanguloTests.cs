using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class RectanguloTests
    {
        [TestCase]
        public void TestResumenAreaDeUnRectangulo()
        {
            var rectangulo = new Rectangulo(2,5);

            decimal result = rectangulo.CalcularArea();

            Assert.AreEqual(10, result);
        }

        [TestCase]
        public void TestResumenAreaDeMasRectangulos()
        {
            var rectangulos = new List<IFormaGeometrica> {
                new Rectangulo(2,5),
                new Rectangulo(2,3)
            };

            decimal result = rectangulos.Sum(c => c.CalcularArea());

            Assert.AreEqual(16, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeUnRectangulo()
        {
            var rectangulo = new Rectangulo(5,2);

            decimal result = rectangulo.CalcularPerimetro();

            Assert.AreEqual(14, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeMasRectangulos()
        {
            var rectangulos = new List<IFormaGeometrica> {
                new Rectangulo(5,2),
                new Rectangulo(2,3)
            };

            decimal result = rectangulos.Sum(c => c.CalcularPerimetro());

            Assert.AreEqual(24, result);
        }
    }
}
