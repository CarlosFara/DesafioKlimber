using DevelopmentChallenge.Data.Interfaces;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class GestorIdiomas : IGestorIdiomas
    {
        private ResourceManager _resourceManager;

        public GestorIdiomas(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void ConfigurarIdioma(Enums.IdiomaEnum idioma)
        {
            _resourceManager = new ResourceManager($"Textos.{idioma}", typeof(GestorIdiomas).Assembly);
        }

        public string ObtenerTexto(string clave)
        {
            return _resourceManager.GetString(clave);
        }
    }
}
