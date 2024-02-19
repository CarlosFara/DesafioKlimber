namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IGestorIdiomas
    {
        void ConfigurarIdioma(Enums.IdiomaEnum idioma);

        string ObtenerTexto(string clave);
    }
}
