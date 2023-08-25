using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGENFAB.Shared.Entities
{
    public class AtribuicaoDeGrupo
    {
        public int PacienteId { get; set; }
        public int GrupoId { get; set; }
        public Paciente? Paciente { get; set; }
        public Grupo? Grupo { get; set; }
    }
}
