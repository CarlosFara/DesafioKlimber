using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using Moq;
using NUnit.Framework;
using System.Resources;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class GestorIdiomasTests
    {
        private IGestorIdiomas gestorIdiomas;
        private Mock<ResourceManager> resourceManagerMock;

        [SetUp]
        public void Init()
        {
            resourceManagerMock = new Mock<ResourceManager>();
            gestorIdiomas = new GestorIdiomas(resourceManagerMock.Object);
        }

        [TestCase]
        public void TestResumenObtenerTexto()
        {
            const string clave = Shared.Constantes.LISTA_VACIA;
            const string textoEsperado = "<h1>Lista vacía de formas!</h1>";

            resourceManagerMock.Setup(x => x.GetString(clave)).Returns(textoEsperado);

            var result = gestorIdiomas.ObtenerTexto(clave);

            Assert.AreEqual(textoEsperado, result);

            resourceManagerMock.Verify(x => x.GetString(clave), Times.Once);
        }
    }
}
