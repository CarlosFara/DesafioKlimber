using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class TrianguloEquilateroTests
    {
        [TestCase]
        public void TestResumenAreaDeUnTrianguloEquilatero()
        {
            var trianguloEquilatero = new TrianguloEquilatero(5);

            decimal result = System.Math.Round(trianguloEquilatero.CalcularArea());

            Assert.AreEqual(11m, result);
        }

        [TestCase]
        public void TestResumenAreaDeMasTrianguloEquilateros()
        {
            var trianguloEquilateros = new List<IFormaGeometrica> {
                new TrianguloEquilatero(5),
                new TrianguloEquilatero(2)
            };

            decimal result = trianguloEquilateros.Sum(c => System.Math.Round(c.CalcularArea()));

            Assert.AreEqual(13m, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeUnTrianguloEquilatero()
        {
            var trianguloEquilatero = new TrianguloEquilatero(5);

            decimal result = trianguloEquilatero.CalcularPerimetro();

            Assert.AreEqual(15, result);
        }

        [TestCase]
        public void TestResumenPerimetroDeMasTrianguloEquilateros()
        {
            var trianguloEquilateros = new List<IFormaGeometrica> {
                new TrianguloEquilatero(5),
                new TrianguloEquilatero(2)
            };

            decimal result = trianguloEquilateros.Sum(c => c.CalcularPerimetro());

            Assert.AreEqual(21, result);
        }
    }
}
