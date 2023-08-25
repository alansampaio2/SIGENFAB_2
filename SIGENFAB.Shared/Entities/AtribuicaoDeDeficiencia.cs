namespace SIGENFAB.Shared.Entities
{
    public class AtribuicaoDeDeficiencia
    {
        public int PacienteId { get; set; }
        public int DeficienciaId { get; set; }
        public Paciente? Paciente { get; set; }
        public Deficiencia? Deficiencia { get; set; }
    }
}
