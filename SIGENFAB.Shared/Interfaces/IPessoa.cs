using SIGENFAB.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGENFAB.Shared.Interfaces
{
    public interface IPessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string CNS { get; set; }
        public DateTime Nascimento { get; set; }
        public Sexo Sexo { get; set; }
    }
}
