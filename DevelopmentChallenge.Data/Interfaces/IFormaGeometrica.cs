namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        Enums.TipoGeometricoEnum Tipo { get; }

        decimal CalcularArea();

        decimal CalcularPerimetro();
    }
}
