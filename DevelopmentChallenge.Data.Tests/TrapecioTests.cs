using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class TrapecioTests
    {
        [TestCase]
        public void TestResumenAreaDeUnTrapecio()
        {
            var trapecio = new Trapecio(5, 7, 3);

            decimal result = System.Math.Round(trapecio.CalcularArea(), 2);

            Assert.AreEqual(25, result);
        }

        [TestCase]
        public void TestResumenAreaDeMasTrapecios()
        {
            var trapecios = new List<IFormaGeometrica> {
                new Trapecio(5, 7, 3),
                new Trapecio(3, 6, 2.5m)
            };

            decimal result = trapecios.Sum(c => System.Math.Round(c.CalcularArea(), 2));

            Assert.AreEqual(37.75m, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeUnTrapecio()
        {
            var trapecio = new Trapecio(5, 7, 3);

            decimal result = System.Math.Round(trapecio.CalcularPerimetro(), 2);

            Assert.AreEqual(20.77m, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeMasTrapecios()
        {
            var trapecios = new List<IFormaGeometrica> {
                new Trapecio(5, 7, 3),
                new Trapecio(3, 6, 2.5m)
            };

            decimal result = trapecios.Sum(c => System.Math.Round(c.CalcularPerimetro(), 2));

            Assert.AreEqual(36.22m, result);
        }
    }
}
