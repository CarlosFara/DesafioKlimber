using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : Interfaces.IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public TipoGeometricoEnum Tipo => TipoGeometricoEnum.TrianguloEquilatero;

        public decimal CalcularArea() => ((decimal)System.Math.Sqrt(3) / 4) * _lado * _lado;

        public decimal CalcularPerimetro() => _lado * 3;
    }
}
