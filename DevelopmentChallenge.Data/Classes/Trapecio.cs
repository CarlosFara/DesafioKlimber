using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : Interfaces.IFormaGeometrica
    {
        private readonly decimal _altura;
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;

        public Trapecio(decimal altura, decimal baseMayor, decimal baseMenor)
        {
            _altura = altura;
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
        }

        public TipoGeometricoEnum Tipo => TipoGeometricoEnum.Trapecio;

        public decimal CalcularArea() => _altura * (_baseMayor + _baseMenor)/2;

        public decimal CalcularPerimetro()
        {
            double baseTrianguloRectangulo = (double)(_baseMayor - _baseMenor) / 2;
            decimal lateral = (decimal)System.Math.Sqrt(baseTrianguloRectangulo * baseTrianguloRectangulo + (double)(_altura * _altura));

            return _baseMayor + _baseMenor + lateral * 2;
        }
    }
}
