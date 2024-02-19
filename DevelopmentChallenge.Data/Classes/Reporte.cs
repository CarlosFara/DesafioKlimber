using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class Reporte
    {
        public IdiomaEnum Idioma { get; }

        private readonly IGestorIdiomas _gestorIdiomas;

        public Reporte(IGestorIdiomas gestorIdiomas)
        {
            _gestorIdiomas = gestorIdiomas;
        }

        public string Imprimir(List<IFormaGeometrica> formas, IdiomaEnum idioma)
        {
            _gestorIdiomas.ConfigurarIdioma(idioma);

            var sb = new StringBuilder();
            
            if (!formas.Any())
            {
                sb.Append(_gestorIdiomas.ObtenerTexto(Constantes.LISTA_VACIA));
            }
            else
            {
                // HEADER
                sb.Append(_gestorIdiomas.ObtenerTexto(Constantes.TITULO));

                var formasAgrupadas = formas.GroupBy(forma => forma.Tipo, (tipo, fa) => new AgrupadorFormas
                {
                    Tipo = tipo,
                    Cantidad = fa.Count(),
                    AreaTotal = fa.Sum(f => f.CalcularArea()),
                    PerimetroTotal = fa.Sum(f => f.CalcularPerimetro())
                });

                foreach (var item in formasAgrupadas)
                {
                    sb.Append(ObtenerLinea(item));
                }

                // FOOTER
                sb.Append(_gestorIdiomas.ObtenerTexto(Constantes.TOTAL));
                sb.Append(formas.Count() + " " + (_gestorIdiomas.ObtenerTexto(Constantes.FORMAS)) + " ");
                sb.Append((_gestorIdiomas.ObtenerTexto(Constantes.PERIMETRO)) + " " + formasAgrupadas.Sum(f => f.PerimetroTotal).ToString("#.##") + " ");
                sb.Append((_gestorIdiomas.ObtenerTexto(Constantes.AREA)) + " " + formasAgrupadas.Sum(f => f.AreaTotal).ToString("#.##"));
            }

            return sb.ToString();
        }

        private string ObtenerLinea(AgrupadorFormas formasAgrupadas)
        {
            string perimetro = _gestorIdiomas.ObtenerTexto(Constantes.PERIMETRO);
            string area = _gestorIdiomas.ObtenerTexto(Constantes.AREA);

            return $"{formasAgrupadas.Cantidad} {TraducirForma(formasAgrupadas)} | {area} {formasAgrupadas.AreaTotal:#.##} | {perimetro} {formasAgrupadas.PerimetroTotal:#.##} <br/>";
        }

        private string TraducirForma(AgrupadorFormas formas)
        {
            string tipoDeForma = formas.Tipo.ToString();
            string nombreForma = $"Nombre_{tipoDeForma}_{(formas.Cantidad == 1 ? "Singular" : "Plural")}";

            return _gestorIdiomas.ObtenerTexto(nombreForma);
        }
    }
}
