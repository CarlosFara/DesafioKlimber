using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Shared;
using Moq;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class ReporteTests
    {
        private Mock<IGestorIdiomas> gestorIdiomasMock;
        private Reporte reporte;

        [SetUp]
        public void Init()
        {
            gestorIdiomasMock = new Mock<IGestorIdiomas>();
            reporte = new Reporte(gestorIdiomasMock.Object);
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            string textoEsperado = "<h1>Lista vacía de formas!</h1>";

            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.LISTA_VACIA)).Returns(textoEsperado);

            var result = reporte.Imprimir(new List<IFormaGeometrica>(), IdiomaEnum.Castellano);

            Assert.AreEqual(textoEsperado, result);

            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.LISTA_VACIA), Times.Once);
            gestorIdiomasMock.Verify(x => x.ConfigurarIdioma(IdiomaEnum.Castellano), Times.Once);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            string textoEsperado = "<h1>Empty list of shapes!</h1>";

            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.LISTA_VACIA)).Returns(textoEsperado);

            var result = reporte.Imprimir(new List<IFormaGeometrica>(), IdiomaEnum.Ingles);

            Assert.AreEqual(textoEsperado, result);

            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.LISTA_VACIA), Times.Once);
            gestorIdiomasMock.Verify(x => x.ConfigurarIdioma(IdiomaEnum.Ingles), Times.Once);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.TITULO)).Returns("<h1>Reporte de Formas</h1>");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto("Nombre_Cuadrado_Singular")).Returns("Cuadrado");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.AREA)).Returns("Area");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.PERIMETRO)).Returns("Perimetro");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.TOTAL)).Returns("TOTAL:<br/>");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.FORMAS)).Returns("formas");

            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = reporte.Imprimir(cuadrados, IdiomaEnum.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);

            gestorIdiomasMock.Verify(x => x.ConfigurarIdioma(IdiomaEnum.Castellano), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.LISTA_VACIA), Times.Never);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.TITULO), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto("Nombre_Cuadrado_Singular"), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.AREA), Times.Exactly(2));
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.PERIMETRO), Times.Exactly(2));
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.TOTAL), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.FORMAS), Times.Once);
        }

        //[TestCase]
        //public void TestResumenListaConMasCuadrados()
        //{
        //    var cuadrados = new List<IFormaGeometrica>
        //    {
        //        new IFormaGeometrica(IFormaGeometrica.Cuadrado, 5),
        //        new IFormaGeometrica(IFormaGeometrica.Cuadrado, 1),
        //        new IFormaGeometrica(IFormaGeometrica.Cuadrado, 3)
        //    };

        //    var resumen = IFormaGeometrica.Imprimir(cuadrados, IFormaGeometrica.Ingles);

        //    Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        //}

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.TITULO)).Returns("<h1>Shapes report</h1>");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto("Nombre_Cuadrado_Plural")).Returns("Squares");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto("Nombre_Circulo_Plural")).Returns("Circles");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto("Nombre_TrianguloEquilatero_Plural")).Returns("Triangles");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.AREA)).Returns("Area");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.PERIMETRO)).Returns("Perimeter");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.TOTAL)).Returns("TOTAL:<br/>");
            gestorIdiomasMock.Setup(x => x.ObtenerTexto(Constantes.FORMAS)).Returns("shapes");

            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = reporte.Imprimir(formas, IdiomaEnum.Ingles);

            // Tuve que corregir el Area de los circulos que no tenía sentido.
            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52,03 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 130,67",
                resumen);

            gestorIdiomasMock.Verify(x => x.ConfigurarIdioma(IdiomaEnum.Ingles), Times.Once);
            gestorIdiomasMock.Verify(x => x.ConfigurarIdioma(IdiomaEnum.Castellano), Times.Never);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.LISTA_VACIA), Times.Never);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.TITULO), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto("Nombre_Cuadrado_Plural"), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto("Nombre_Circulo_Plural"), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto("Nombre_TrianguloEquilatero_Plural"), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.AREA), Times.Exactly(4));
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.PERIMETRO), Times.Exactly(4));
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.TOTAL), Times.Once);
            gestorIdiomasMock.Verify(x => x.ObtenerTexto(Constantes.FORMAS), Times.Once);
        }

        //[TestCase]
        //public void TestResumenListaConMasTiposEnCastellano()
        //{
        //    var formas = new List<IFormaGeometrica>
        //    {
        //        new IFormaGeometrica(IFormaGeometrica.Cuadrado, 5),
        //        new IFormaGeometrica(IFormaGeometrica.Circulo, 3),
        //        new IFormaGeometrica(IFormaGeometrica.TrianguloEquilatero, 4),
        //        new IFormaGeometrica(IFormaGeometrica.Cuadrado, 2),
        //        new IFormaGeometrica(IFormaGeometrica.TrianguloEquilatero, 9),
        //        new IFormaGeometrica(IFormaGeometrica.Circulo, 2.75m),
        //        new IFormaGeometrica(IFormaGeometrica.TrianguloEquilatero, 4.2m)
        //    };

        //    var resumen = IFormaGeometrica.Imprimir(formas, IFormaGeometrica.Castellano);

        //    Assert.AreEqual(
        //        "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
        //        resumen);
        //}


    }
}
