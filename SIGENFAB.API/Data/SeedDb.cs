using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Data
{
    public class SeedDb
    {
        private readonly Contexto _context;

        public SeedDb(Contexto context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await InserirDeficienciasAsync();
        }

        private async Task InserirDeficienciasAsync()
        {
            if (!_context.Deficiencias.Any())
            {
                _context.Deficiencias.Add(new Deficiencia { Nome = "Física", Descricao = "alteração completa ou parcial de um ou mais segmentos do corpo humano, acarretando o comprometimento da função física, apresentando-se sob a forma de paraplegia, paraparesia, monoplegia, monoparesia, tetraplegia, tetraparesia, triplegia, triparesia, hemiplegia, hemiparesia, ostomia, amputação ou ausência de membro, paralisia cerebral, membros com deformidade congênita ou adquirida, nanismo." });
                _context.Deficiencias.Add(new Deficiencia{ Nome = "Auditiva", Descricao = "perda bilateral, parcial ou total, de 41 decibéis (dB) ou mais, aferida por audiograma nas frequências de 500HZ, 1.000HZ, 2.000Hz e 3.000Hz" });
                _context.Deficiencias.Add(new Deficiencia{ Nome = "Intelectual/Cognitiva", Descricao = "funcionamento intelectual significativamente inferior à média, com manifestação antes dos 18 anos e limitações associadas a duas ou mais habilidades adaptativas" });
                _context.Deficiencias.Add(new Deficiencia{ Nome = "Visual", Descricao = "" });
            }
            await _context.SaveChangesAsync();
        }
    }
}
