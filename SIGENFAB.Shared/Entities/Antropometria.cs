using SIGENFAB.Shared.Enums;
using SIGENFAB.Shared.Models;

namespace SIGENFAB.Shared.Entities
{
    public class Antropometria
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public DateTime Data { get; set; }
        public double? Altura { get; set; }
        public double? Peso { get; set; }
        public double? ParimetroCefalico { get; set; }
        public double? PerimetroAbdominal { get; set; }

        public IMC IMC()
        {
            //TODO: Terminar o método: calcular e classifica o IMC
            if (Peso.HasValue && Altura.HasValue)
            {
                var resultado = Peso / (Altura * Altura);

                return new IMC()
                {

                };
            }

            return new IMC();
        }

        private IntervaloDePeso CalculoPesoIdeal(double imcLimiteInferior, double imcLimiteSuperior, double altura)
        {
            var menorPeso = imcLimiteInferior * (altura * altura);
            var maiorPeso = imcLimiteSuperior * (altura * altura);

            return new IntervaloDePeso
            {
                PesoLimiteInferior = menorPeso,
                PesoLimiteSuperior = maiorPeso,
            };
        }

        private string ClassificacaoNutricional(double imc, int idade, Sexo sexo, bool gestante)
        {
            var resultado = string.Empty;

            //TODO: Rotina para classificação nutricional
            if (idade >= 20)
            {
                switch (imc)
                {
                    case < ConstantesIMC.IMC1:
                        resultado = ConstantesClassificacaoNutricional.AbaixoPeso;
                        break;
                }
            }
            return resultado;
        }
    }
}
