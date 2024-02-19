using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : Interfaces.IFormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal radio)
        {
            _radio = radio;
        }

        public TipoGeometricoEnum Tipo => TipoGeometricoEnum.Circulo;

        public decimal CalcularArea() => (decimal)System.Math.PI * _radio * _radio;

        public decimal CalcularPerimetro() => (decimal)System.Math.PI * _radio;
    }
}
