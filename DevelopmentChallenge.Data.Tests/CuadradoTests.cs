using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class CuadradoTests
    {
        [TestCase]
        public void TestResumenAreaDeUnCuadrado()
        {
            var cuadrado = new Cuadrado(5);

            decimal result = cuadrado.CalcularArea();

            Assert.AreEqual(25, result);
        }

        [TestCase]
        public void TestResumenAreaDeMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica> {
                new Cuadrado(5),
                new Cuadrado(2)
            };

            decimal result = cuadrados.Sum(c => c.CalcularArea());

            Assert.AreEqual(29, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeUnCuadrado()
        {
            var cuadrado = new Cuadrado(5);

            decimal result = cuadrado.CalcularPerimetro();

            Assert.AreEqual(20, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica> {
                new Cuadrado(5),
                new Cuadrado(2)
            };

            decimal result = cuadrados.Sum(c => c.CalcularPerimetro());

            Assert.AreEqual(28, result);
        }
    }
}
