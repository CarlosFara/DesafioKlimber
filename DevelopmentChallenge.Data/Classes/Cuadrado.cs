using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : Interfaces.IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public TipoGeometricoEnum Tipo => TipoGeometricoEnum.Cuadrado;

        public decimal CalcularArea() => _lado * _lado;

        public decimal CalcularPerimetro() => _lado* 4;
    }
}
