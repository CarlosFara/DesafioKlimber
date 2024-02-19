using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : Interfaces.IFormaGeometrica
    {
        private readonly decimal _alto;
        private readonly decimal _ancho;

        public Rectangulo(decimal ancho, decimal alto)
        {
            _ancho = ancho;
            _alto = alto;
        }

        public TipoGeometricoEnum Tipo => TipoGeometricoEnum.Rectangulo;

        public decimal CalcularArea() => _ancho * _alto;

        public decimal CalcularPerimetro() => (_ancho + _alto) * 2;
    }
}
