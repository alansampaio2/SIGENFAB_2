namespace SIGENFAB.Shared.Models
{
    public class IMC
    {
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Resultado { get; set; }
        public string ClassificacaoNutricional { get; set; } = null!;
        public IntervaloDePeso? PesoIdeal { get; set; }
        public IntervaloDePeso? GanhoDePesoIdeal { get; set; }
        public IntervaloDePeso? PerdaDePesoIdeal { get; set; }
    }

    public class IntervaloDePeso
    {
        public double PesoLimiteInferior { get; set; }
        public double PesoLimiteSuperior { get; set; }
    }

    public static class ConstantesIMC
    {
        public const double IMC1 = 18.5;
        public const double IMC2 = 24.9;
        public const double IMC3 = 25.0;
        public const double IMC4 = 29.9;
        public const double IMC5 = 30.0;
        public const double IMC6 = 34.9;
        public const double IMC7 = 35.0;
        public const double IMC8 = 39.9;
        public const double IMC9 = 40.0;
    }

    public static class ConstantesClassificacaoNutricional
    {
        public const string AbaixoPeso = "Abaixo do Peso";
        public const string PesoNormal = "Peso Normal";
        public const string PreObesidade = "Pré-Obesidade";
        public const string ObesidadeGrauUm = "Obesidade Grau I";
        public const string ObesidadeGrauDois = "Obesidade Grau II";
        public const string ObesidadeGrauTres = "Obesidade Grau III";
    }
}
