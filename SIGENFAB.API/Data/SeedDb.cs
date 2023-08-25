using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata;
using SIGENFAB.Shared.Entities;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System;
using SIGENFAB.API.Managers;
using Microsoft.AspNetCore.Identity;
using SIGENFAB.Shared.Enums;
using SIGENFAB.Shared.Constatntes;

namespace SIGENFAB.API.Data
{
    public class SeedDb
    {
        private readonly Contexto _context;
        private readonly IUsuarioManager _userManager;

        public SeedDb(Contexto context, IUsuarioManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await InserirDeficienciasAsync();
            await InserirEstados();
            await InserirUnidades();
            await VerificarFuncoesAsync();

            var usuarioEnfermeiro = await VerificarUsuario(UsuarioTipo.Enfermeiro, "Arnol", "Calixto Oliveira Neto", "014.164.915-11", "700.9079.3500.6691",
                new DateTime(1985, 4, 17), Sexo.MASCULINO, FuncaoConstante.Enfermeiro);
            var usuarioTecEnfermagem = await VerificarUsuario(UsuarioTipo.TecEnfermagem, "Viviane", "Da Silva Martin Canuto", "016.125.185-40", "700.5057.6643.0957",
                new DateTime(1982, 3, 21), Sexo.FEMININO, FuncaoConstante.TecEnfermagem);
            var usuarioACS = await VerificarUsuario(UsuarioTipo.ACS, "Roberto", "De Jesus Ramos", "001.372.415-00", "701.0028.9588.0290",
                new DateTime(1981, 6, 3), Sexo.MASCULINO, FuncaoConstante.ACS);
            var usuarioAdministrador = await VerificarUsuario(UsuarioTipo.Administrador, "Alan", "Mangueira Sampaio", "975.199.955-34", "705.0030.6046.8457",
                new DateTime(1978, 7, 19), Sexo.MASCULINO, FuncaoConstante.Administrador);

            var usuarioPacienteAdultoMas = await VerificarUsuario(UsuarioTipo.Paciente, "Roberto", "De Jesus Ramos", "001.372.415-00", "701.0028.9588.0290",
                new DateTime(1981, 6, 3), Sexo.MASCULINO, FuncaoConstante.Paciente);
            var usuarioPacienteAdultoFem = await VerificarUsuario(UsuarioTipo.Paciente, "Fernanda", "Tavares de Araújo de Alcantra", "366.008.178-79", "706.2025.3902.3764",
                new DateTime(1988, 10, 15), Sexo.FEMININO, FuncaoConstante.Paciente);
            var usuarioPacienteIdosoMasc = await VerificarUsuario(UsuarioTipo.Paciente, "José", "Carlos Dos Santos", "840.595.325-68", "700.2019.4719.3727",
                new DateTime(1954, 1, 20), Sexo.MASCULINO, FuncaoConstante.Paciente);
            var usuarioPacienteIdosoFem = await VerificarUsuario(UsuarioTipo.Paciente, "Maria", "José Bispo Dos Santos", "454.791.660-85", "700.5071.7655.2851",
                new DateTime(1967, 5, 20), Sexo.FEMININO, FuncaoConstante.Paciente);

            if (!_context.Pacientes.Any())
            {
                await InserirPaciente(null, "114.396.275-33", "702.1087.2276.9692", "Júlia", "Olivaira Silva dos Santos", "Cláudia Betania Silva dos Santos",
                    "Cleverton Oliveira Santos", new DateTime(2019, 8, 4), "", Escolaridade.ANALFABETO, Sexo.FEMININO, EstadoCivil.Solteiro, IdentidadeDeGenero.NAO_INFORMADO,
                    OrientacaoSexual.NAO_INFORMADO, RacaCor.PARDA, "", true, false, StatusMercadoDeTrabalho.NENHUM, false, "");

                await InserirPaciente(usuarioPacienteAdultoMas, usuarioPacienteAdultoMas.CPF, usuarioPacienteAdultoMas.CNS, usuarioPacienteAdultoMas.Nome,
                    usuarioPacienteAdultoMas.Sobrenome, "Maria do Carmo de Jesus Ramos", "Eronildes de Jesus Ramos", usuarioPacienteAdultoMas.Nascimento,
                    "", Escolaridade.FUNDAMENTAL_COMPLETO, Sexo.MASCULINO, EstadoCivil.Uniao_Estavel, IdentidadeDeGenero.NAO_INFORMADO, OrientacaoSexual.NAO_INFORMADO,
                    RacaCor.PARDA, "", false, false, StatusMercadoDeTrabalho.ASSALARIADO_SEM_CARTEIRA, false, "");

                await InserirPaciente(usuarioPacienteAdultoFem, usuarioPacienteAdultoFem.CPF, usuarioPacienteAdultoFem.CNS, usuarioPacienteAdultoFem.Nome,
                    usuarioPacienteAdultoFem.Sobrenome, "Tania Tavares dos Santos", "Osmário dos Santos Araújo", usuarioPacienteAdultoFem.Nascimento,
                    "", Escolaridade.MEDIO_INCOMPLETO, Sexo.FEMININO, EstadoCivil.Solteiro, IdentidadeDeGenero.NAO_INFORMADO, OrientacaoSexual.HETERESSEXUAL,
                    RacaCor.PARDA, "", false, false, StatusMercadoDeTrabalho.ASSALARIADO_SEM_CARTEIRA, false, "");

                await InserirPaciente(usuarioPacienteIdosoMasc, usuarioPacienteIdosoMasc.CPF, usuarioPacienteIdosoMasc.CNS, usuarioPacienteIdosoMasc.Nome,
                    usuarioPacienteIdosoMasc.Sobrenome, "Maria Joana dos Santos", "", usuarioPacienteIdosoMasc.Nascimento,
                    "", Escolaridade.MEDIO_INCOMPLETO, Sexo.MASCULINO, EstadoCivil.Viuvo, IdentidadeDeGenero.NAO_INFORMADO, OrientacaoSexual.HETERESSEXUAL,
                    RacaCor.PARDA, "", false, false, StatusMercadoDeTrabalho.APOSENTADO_PENSIONISTA, false, "");

                await InserirPaciente(usuarioPacienteIdosoMasc, usuarioPacienteIdosoMasc.CPF, usuarioPacienteIdosoMasc.CNS, usuarioPacienteIdosoMasc.Nome,
                    usuarioPacienteIdosoMasc.Sobrenome, "Josefa Bispo dos Santos", "Durval Bispo dos Santos", usuarioPacienteIdosoMasc.Nascimento,
                    "", Escolaridade.MEDIO_INCOMPLETO, Sexo.FEMININO, EstadoCivil.Casado, IdentidadeDeGenero.NAO_INFORMADO, OrientacaoSexual.HETERESSEXUAL,
                    RacaCor.PARDA, "", false, false, StatusMercadoDeTrabalho.APOSENTADO_PENSIONISTA, false, "");
            }

            if (!_context.Enfermeiros.Any())
            {
                await InserirEnfermeiroAdministrador(usuarioAdministrador, "123456", "121119", null);
                await InserirEnfermeiro(usuarioEnfermeiro, "123456", "546987", null);
            }

            if (!_context.TecnicosEnfermagem.Any())
            {
                await InserirTecEnfermagem(usuarioTecEnfermagem, "456987", "514236", null);
            }

            if (!_context.AgentesSaude.Any())
            {
                await InserirACS(usuarioACS, "123456", null);
            }
        }

        private async Task InserirDeficienciasAsync()
        {
            if (!_context.Deficiencias.Any())
            {
                _context.Deficiencias.Add(new Deficiencia { Nome = "Física", Descricao = "alteração completa ou parcial de um ou mais segmentos do corpo humano, acarretando o comprometimento da função física, apresentando-se sob a forma de paraplegia, paraparesia, monoplegia, monoparesia, tetraplegia, tetraparesia, triplegia, triparesia, hemiplegia, hemiparesia, ostomia, amputação ou ausência de membro, paralisia cerebral, membros com deformidade congênita ou adquirida, nanismo." });
                _context.Deficiencias.Add(new Deficiencia { Nome = "Auditiva", Descricao = "perda bilateral, parcial ou total, de 41 decibéis (dB) ou mais, aferida por audiograma nas frequências de 500HZ, 1.000HZ, 2.000Hz e 3.000Hz" });
                _context.Deficiencias.Add(new Deficiencia { Nome = "Intelectual/Cognitiva", Descricao = "funcionamento intelectual significativamente inferior à média, com manifestação antes dos 18 anos e limitações associadas a duas ou mais habilidades adaptativas" });
                _context.Deficiencias.Add(new Deficiencia { Nome = "Visual", Descricao = "" });
            }
            await _context.SaveChangesAsync();
        }

        private async Task InserirPaciente(Usuario? usuario, string cpf, string cns, string nome, string sobrenome, string mae, string pai, DateTime nascimento,
            string nis, Escolaridade escolaridade, Sexo sexo, EstadoCivil estadoCivil, IdentidadeDeGenero identidadeDeGenero, OrientacaoSexual orientacaoSexual,
            RacaCor racaCor, string ocupacao, bool frequentaEscola, bool frequentaCreche, StatusMercadoDeTrabalho statusMercadoDeTrabalho, bool planoDeSaude,
            string nomeSocial)
        {
            var paciente = new Paciente
            {
                Usuario = usuario,
                CNS = cns,
                CPF = cpf,
                Mae = mae,
                Pai = pai,
                Nascimento = nascimento,
                Nome = nome,
                Sobrenome = sobrenome,
                NIS = nis,
                Escolaridade = escolaridade,
                IdentidadeDeGenero = identidadeDeGenero,
                EstadoCivil = estadoCivil,
                Sexo = sexo,
                OrientacaoSexual = orientacaoSexual,
                Ocupacao = ocupacao,
                RacaCor = racaCor,
                FrequentaEscola = frequentaEscola,
                FrequentaCreche = frequentaCreche,
                StatusMercadoDeTrabalho = statusMercadoDeTrabalho,
                PlanoDeSaude = planoDeSaude,
                NomeSocial = nomeSocial,
                UsuarioId = usuario != null ? null : usuario!.Id,
            };

            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        private async Task InserirEnfermeiro(Usuario? usuario, string matricula, string coren_uf, int? area_id)
        {
            var enfermeiro = new Enfermeiro()
            {
                AreaId = area_id,
                COREN_UF = coren_uf,
                Matricula = matricula,
                Usuario = usuario,
            };

            await _context.Enfermeiros.AddAsync(enfermeiro);
            await _context.SaveChangesAsync();
        }

        private async Task InserirEnfermeiroAdministrador(Usuario? usuario, string matricula, string coren_uf, int? area_id)
        {
            var admin = new Enfermeiro()
            {
                AreaId = area_id,
                COREN_UF = coren_uf,
                Matricula = matricula,
                Usuario = usuario,
            };

            await _context.Enfermeiros.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        private async Task InserirTecEnfermagem(Usuario? usuario, string matricula, string coren_uf, int? area_id)
        {
            var tecnico = new TecEnfermagem()
            {
                AreaId = area_id,
                COREN_UF = coren_uf,
                Matricula = matricula,
                Usuario = usuario,
            };

            await _context.TecnicosEnfermagem.AddAsync(tecnico);
            await _context.SaveChangesAsync();
        }

        private async Task InserirACS(Usuario? usuario, string matricula, int? micro_id)
        {
            var acs = new AgenteSaude()
            {
                MicroId = micro_id,
                Matricula = matricula,
                Usuario = usuario,
            };

            await _context.AgentesSaude.AddAsync(acs);
            await _context.SaveChangesAsync();
        }

        private async Task InserirEstados()
        {
            if (!_context.Estados.Any())
            {
                _context.Estados.Add(new Estado { Descricao = "Acre", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Alagoas", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Amazonas", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Amapá", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Bahia", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Ceará", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Distrito Federal", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Espírito Santo", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Goiás", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Maranhão", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Minas Gerais", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Mato Grosso do Sul", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Mato Grosso", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Pará", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Paraíba", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Pernambuco", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Piauí", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Paraná", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Rio de Janeiro", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Rio Grande do Norte", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Rondônia", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Roraima", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Rio Grande do Sul", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Santa Catarina", Sigla = "" });
                _context.Estados.Add(new Estado
                {
                    Descricao = "Sergipe",
                    Sigla = "",
                    Cidades = new List<Cidade>()
                    {
                        new Cidade { Descricao = "Altos Verdes (Carira)" },
                        new Cidade { Descricao = "Amparo de São Francisco" },
                        new Cidade { Descricao = "Aquidabã" },
                        new Cidade
                        {
                            Descricao = "Aracaju",
                            Bairros = new List<Bairro>()
                            {
                                new Bairro { Descricao = "17 de Março" },
                                new Bairro { Descricao = "Aeroporto" },
                                new Bairro { Descricao = "América" },
                                new Bairro { Descricao = "Atalaia" },
                                new Bairro { Descricao = "Bugio" },
                                new Bairro { Descricao = "Capucho" },
                                new Bairro { Descricao = "Centro" },
                                new Bairro { Descricao = "Cidade Nova" },
                                new Bairro { Descricao = "Cirurgia" },
                                new Bairro { Descricao = "Coroa do Meio" },
                                new Bairro { Descricao = "Dezoito do Forte" },
                                new Bairro { Descricao = "Farolândia" },
                                new Bairro { Descricao = "Getúlio Vargas" },
                                new Bairro { Descricao = "Grageru" },
                                new Bairro { Descricao = "Inácio Barbosa" },
                                new Bairro { Descricao = "Industrial" },
                                new Bairro { Descricao = "Jabotiana" },
                                new Bairro { Descricao = "Japãozinho" },
                                new Bairro { Descricao = "Jardim Centenário" },
                                new Bairro { Descricao = "Jardins" },
                                new Bairro { Descricao = "José Conrado de Araújo" },
                                new Bairro { Descricao = "Lamarão" },
                                new Bairro
                                {
                                    Descricao = "Luzia",
                                    Logradouros = new List<Logradouro>()
                                    {
                                        new Logradouro { CEP = "49045-010", Descricao = "Avenida Adelbrando Franco Menezes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-015", Descricao = "Rua Padre Nestor Sampaio", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-020", Descricao = "Rua Adelermo Brito Bomfim", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-030", Descricao = "Rua Maye Bell Taylor", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-033", Descricao = "Rua X", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-040", Descricao = "Praça Álvaro Fontes da Silva", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-050", Descricao = "Conjunto Alvorada", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-060", Descricao = "Rua Isaías Amâncio de Jesus", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-070", Descricao = "Rua Antônio Teles da Costa", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-080", Descricao = "Rua Armando Barros", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-083", Descricao = "Rua Matilde Silva Lima", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-086", Descricao = "Rua José Francisco de Oliveira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-090", Descricao = "Rua Trabalhador Ailton Marques dos Santos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-100", Descricao = "Rua Aldjebran Garcia Moreno", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-103", Descricao = "Praça Rubens Paiva", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-110", Descricao = "Rua Benjamin Fontes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-120", Descricao = "Rua Cândido Portinari", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-130", Descricao = "Praça Carlos Hardman", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-133", Descricao = "Rua Terezinha da Costa Santos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-136", Descricao = "Rua Maria Gonçalves Lima de Azevêdo", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-139", Descricao = "Rua Edivaldo Simões Cruz", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-140", Descricao = "Rua Cícero Monteiro Filho", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-150", Descricao = "Rua Cordeiro de Morais", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-170", Descricao = "Rua Desembargador Carlos Vieira Sobral", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-190", Descricao = "Rua Doutor Márcio Rollemberg Leite", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-200", Descricao = "Rua Heráclito Muniz Barreto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-210", Descricao = "Rua Treze de Maio", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-230", Descricao = "Rua Doutor Thieres Gonçalves Santana", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-240", Descricao = "Rua Edgar Leite", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-250", Descricao = "Rua Engenheiro Antônio Gonçalves Soares", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-253", Descricao = "Rua Jornalista João de Menezes Barros Filho", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-256", Descricao = "Rua Dona Abigail Ferreira Araújo Ramos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-260", Descricao = "Rua Erundina Nobre Santos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-270", Descricao = "Rua Frederico Ozanam", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-280", Descricao = "Avenida Gonçalo Rolemberg Leite", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-285", Descricao = "Avenida Doutor Francisco Moreira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-290", Descricao = "Rua Hélio Maranhão", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-300", Descricao = "Rua da Integração", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-310", Descricao = "Rua Moisés Costa", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-320", Descricao = "Conjunto Jessé Pinto Freire", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-330", Descricao = "Rua João do Sacramento", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-350", Descricao = "Travessa João José Bittencourt Calazans", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-360", Descricao = "Rua Jornalista Deolindo Nascimento", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-370", Descricao = "Rua Jornalista Evandro Barros", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-373", Descricao = "Rua Gilson Pereira de Almeida", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-376", Descricao = "Rua Ananias Ferreira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-380", Descricao = "Rua José Alves das Neves", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-390", Descricao = "Rua Humberto Peixoto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-400", Descricao = "Rua José Elson Fontes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-410", Descricao = "Rua Jovino Silva", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-413", Descricao = "Rua Vereador João Alves da Silva", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-420", Descricao = "Rua Luiz Cordeiro Morais", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-423", Descricao = "Avenida General Djenal Tavares de Queroz", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-426", Descricao = "Rua Luís Ricardo Soares Freire", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-430", Descricao = "Rua Luiz Dias Mota", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-440", Descricao = "Rua Antônio José de Souza", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-450", Descricao = "Praça Paulo Barreto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-460", Descricao = "Rua Manoel Donizetti Vieira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-470", Descricao = "Rua Manoel dos Passos de Oliveira Teles", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-480", Descricao = "Rua Manoel Gomes da Rocha", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-490", Descricao = "Rua Marina Maciel", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-500", Descricao = "Rua Marise Almeida Santos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-510", Descricao = "Rua Ministro Nelson Hungria", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-520", Descricao = "Rua Moacyr Lopes Poconé", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-530", Descricao = "Conjunto Novo Horizonte", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-540", Descricao = "Rua Osvaldina Rocha Rosa", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-550", Descricao = "Rua Padre Caldas", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-560", Descricao = "Rua Pastor Ernesto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-570", Descricao = "Rua Pedro Ferreira Guimarães", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-580", Descricao = "Rua Perolina Silva Lima", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-620", Descricao = "Praça Professor Genaro Plech", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-630", Descricao = "Praça Raul Batista", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-640", Descricao = "Praça Sérgio Guttemberg", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-650", Descricao = "Rua Tenente Eduardo Dantas", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-660", Descricao = "Travessa Thomaz Narciso Ferreira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-670", Descricao = "Rua João Melo", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-680", Descricao = "Praça Vereador Nivaldo Teles de Menezes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-690", Descricao = "Rua Wilson Almeida Santana", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-700", Descricao = "Estrada da Luzia", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-703", Descricao = "Rua Maria Carmelita Santos de Andrade", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-706", Descricao = "Rua Palmira Ramos Teles", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-710", Descricao = "Rua Doutor Manoel Cândido Pereira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-720", Descricao = "Rua Bispo Ariosvaldo de Oliveira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-730", Descricao = "Rua Renato Santos Teixeira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-733", Descricao = "Rua B (Conol II)", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-736", Descricao = "Rua Missionária Mundica Gomes Santana", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-740", Descricao = "Rua Manoel Dias da Costa", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-750", Descricao = "Rua Alessandro Oliveira Porto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-760", Descricao = "Avenida Hermes Fontes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-763", Descricao = "Rua F", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-770", Descricao = "Rua Anália Pinha de Assis", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-773", Descricao = "Rua José Pereira da Silva", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-780", Descricao = "Rua Diácono Atanázio Alves dos Reis", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-790", Descricao = "Rua Josafá Simões Mariu", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-800", Descricao = "Rua Alcino Oliveira Neto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-810", Descricao = "Rua Artur Porfírio de Farias", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-820", Descricao = "Rua Maria Helena Passos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-830", Descricao = "Rua Manoel Avelar Correia", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-840", Descricao = "Rua Soldado Petronilo José dos Santos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49045-843", Descricao = "Rua Hamilton Monteiro Freire", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-000", Descricao = "Rua João Bispo Menezes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-020", Descricao = "Rua José David Menezes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-030", Descricao = "Rua Francisco Ferreira de Oliveira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-050", Descricao = "Rua Abdias Nascimento", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-060", Descricao = "Praça Ávio Seixas Brito", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-070", Descricao = "Rua Juarez Gomes da Rocha", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-080", Descricao = "Rua Pedro José do Nascimento", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-100", Descricao = "Rua Iolanda Leite Moura", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-120", Descricao = "Rua Mário Cardoso Chagas", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-240", Descricao = "Quadra Manoel Batista da Costa", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49046-970", Descricao = "Avenida Adélia Franco, 3138", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-000", Descricao = "Avenida Luciano Monteiro Sobral", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-010", Descricao = "Avenida Adélia Franco", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-020", Descricao = "Rua Antônio Alexandre Menezes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-030", Descricao = "Jardim Baiano", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-040", Descricao = "Rua Cesário de Gois Pessoa", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-050", Descricao = "Rua Cônego José Ferreira Machado", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-060", Descricao = "Rua Coronel Armando Mendes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-070", Descricao = "Rua Deputado Matos Teles", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-080", Descricao = "Rua José Ramos Figueiredo", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-090", Descricao = "Rua Doutor Álvaro da Silva Brito", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-100", Descricao = "Rua Doutor Canuto Garcia Moreno", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-110", Descricao = "Rua Doutor Carlos Alberto Rolla", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-120", Descricao = "Rua Doutor Carlos Henrique de Carvalho", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-130", Descricao = "Rua Doutor Luiz Antônio de Farias", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-140", Descricao = "Rua Durval Madureira Freire", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-150", Descricao = "Rua Estêvão Pereira Coelho", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-160", Descricao = "Rua Guilherme José Vieira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-170", Descricao = "Rua Humberto Porto Dória", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-173", Descricao = "Rua Manoel Nunes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-176", Descricao = "Rua Desembargador José Rodrigues Nou", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-180", Descricao = "Rua Doutor João Santana", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-190", Descricao = "Rua João Mascarenhas", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-200", Descricao = "Rua João Gomes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-210", Descricao = "Rua José Mendonça", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-220", Descricao = "Rua Laurindo Cerqueira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-230", Descricao = "Rua Manoel Maurício Cardoso", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-240", Descricao = "Rua Manoel Pereira Guimarães", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-250", Descricao = "Rua Martinho de Melo Cardoso", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-260", Descricao = "Rua Antônio Vieira de Menezes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-263", Descricao = "Travessa Robson Pereira Santos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-270", Descricao = "Rua Paulino Fernandes de Barros", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-280", Descricao = "Rua Pedro Diniz Leite de Oliveira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-290", Descricao = "Rua Pedro Teixeira Guimarães", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-300", Descricao = "Rua Policarpo Diniz Rezende", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-303", Descricao = "Rua Pedro Ferreira da Silva", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-306", Descricao = "Rua H1", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-309", Descricao = "Rua Napoleão Teles de Oliveira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-310", Descricao = "Rua Professor Humberto da Silva Moura", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-320", Descricao = "Rua Radialista Wolney Silva", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-330", Descricao = "Rua Rodolfo Ramos Fontes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-340", Descricao = "Rua São Pedro", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-350", Descricao = "Rua Sílvio Fontes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-360", Descricao = "Rua Theodomiro de Mello Barreto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-370", Descricao = "Rua Vereador Etelvino Barreto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-380", Descricao = "Rua Lourival do Prado Barreto", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-383", Descricao = "Rua Luciano Monteiro Sobral", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-390", Descricao = "Rua José Deodoro Santos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-400", Descricao = "Rua Jessé Pereira Nunes", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-406", Descricao = "Rua Pina Ramos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-410", Descricao = "Rua João Rodrigues de Miranda", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-420", Descricao = "Praça Anival Dantas", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-430", Descricao = "Avenida Dulce Diniz", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-440", Descricao = "Rua Ascendino Ângelo dos Reis", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-450", Descricao = "Rua Radialista Cadmo Nascimento", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-460", Descricao = "Rua Poeta João Salles de Campos", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-480", Descricao = "Conjunto Presidente Médici I", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-490", Descricao = "Conjunto Presidente Médici II", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-500", Descricao = "Rua Doutor Sancho de Barros Pimentel", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-510", Descricao = "Rua Maria Dantas de Mendonça", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-520", Descricao = "Rua João Carlos de Oliveira", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-523", Descricao = "Rua B (Jd Gravatá)", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-526", Descricao = "Rua Trinta e Dois", Longitude = 0.0, Latitude = 0.0 },
                                        new Logradouro { CEP = "49048-530", Descricao = "Avenida Presidente Tancredo Neves", Longitude = 0.0, Latitude = 0.0 },
                                    }
                                },
                                new Bairro { Descricao = "Novo Paraíso" },
                                new Bairro { Descricao = "Olaria" },
                                new Bairro { Descricao = "Palestina" },
                                new Bairro { Descricao = "Pereira Lobo" },
                                new Bairro
                                {
                                    Descricao = "Ponto Novo",
                                    Logradouros = new List<Logradouro>()
                                    {
                                        new Logradouro { CEP = "49097-000", Descricao = "Avenida São João Batista", Longitude = -37.0779354, Latitude = -10.9310735 },
                                    }
                                },
                                new Bairro { Descricao = "Porto DAntas" },
                                new Bairro { Descricao = "Salgado Filho" },
                                new Bairro { Descricao = "Santa Maria" },
                                new Bairro { Descricao = "Santo Antônio" },
                                new Bairro { Descricao = "Santos Dumont" },
                                new Bairro { Descricao = "São Conrado" },
                                new Bairro { Descricao = "São José" },
                                new Bairro { Descricao = "Siqueira Campos" },
                                new Bairro { Descricao = "Soledade" },
                                new Bairro { Descricao = "Suíssa" },
                                new Bairro { Descricao = "Treze de Julho" },
                                new Bairro { Descricao = "Zona de Expansão (Areia Branca)" },
                                new Bairro { Descricao = "Zona de Expansão (Aruana)" },
                                new Bairro { Descricao = "Zona de Expansão (Mosqueiro)" },
                                new Bairro { Descricao = "Zona de Expansão (Robalo)" },
                            }
                        },
                        new Cidade { Descricao = "Arauá" },
                        new Cidade { Descricao = "Areia Branca" },
                        new Cidade { Descricao = "Barra dos Coqueiros" },
                        new Cidade { Descricao = "Barracas (Capela)" },
                        new Cidade { Descricao = "Boquim" },
                        new Cidade { Descricao = "Brejo Grande" },
                        new Cidade { Descricao = "Campo do Brito" },
                        new Cidade { Descricao = "Canhoba" },
                        new Cidade { Descricao = "Canindé de São Francisco" },
                        new Cidade { Descricao = "Capela" },
                        new Cidade { Descricao = "Carira" },
                        new Cidade { Descricao = "Carmópolis" },
                        new Cidade { Descricao = "Cedro de São João" },
                        new Cidade { Descricao = "Cristinápolis" },
                        new Cidade { Descricao = "Cumbe" },
                        new Cidade { Descricao = "Divina Pastora" },
                        new Cidade { Descricao = "Estância" },
                        new Cidade { Descricao = "Feira Nova" },
                        new Cidade { Descricao = "Frei Paulo" },
                        new Cidade { Descricao = "Gararu" },
                        new Cidade { Descricao = "General Maynard" },
                        new Cidade { Descricao = "Graccho Cardoso" },
                        new Cidade { Descricao = "Ilha das Flores" },
                        new Cidade { Descricao = "Indiaroba" },
                        new Cidade { Descricao = "Itabaiana" },
                        new Cidade { Descricao = "Itabaianinha" },
                        new Cidade { Descricao = "Itabi" },
                        new Cidade { Descricao = "Itaporanga DAjuda" },
                        new Cidade { Descricao = "Japaratuba" },
                        new Cidade { Descricao = "Japoatã" },
                        new Cidade { Descricao = "Lagarto" },
                        new Cidade { Descricao = "Lagoa Funda (Gararu)" },
                        new Cidade { Descricao = "Laranjeiras" },
                        new Cidade { Descricao = "Macambira" },
                        new Cidade { Descricao = "Malhada dos Bois" },
                        new Cidade { Descricao = "Malhador" },
                        new Cidade { Descricao = "Maruim" },
                        new Cidade { Descricao = "Miranda (Capela)" },
                        new Cidade { Descricao = "Moita Bonita" },
                        new Cidade { Descricao = "Monte Alegre de Sergipe" },
                        new Cidade { Descricao = "Muribeca" },
                        new Cidade { Descricao = "Neópolis" },
                        new Cidade { Descricao = "Nossa Senhora Aparecida" },
                        new Cidade { Descricao = "Nossa Senhora da Glória" },
                        new Cidade { Descricao = "Nossa Senhora das Dores" },
                        new Cidade { Descricao = "Nossa Senhora de Lourdes" },
                        new Cidade { Descricao = "Nossa Senhora do Socorro" },
                        new Cidade { Descricao = "Pacatuba" },
                        new Cidade { Descricao = "Palmares (Riachão do Dantas)" },
                        new Cidade { Descricao = "Pedra Mole" },
                        new Cidade { Descricao = "Pedras (Capela)" },
                        new Cidade { Descricao = "Pedrinhas" },
                        new Cidade { Descricao = "Pinhão" },
                        new Cidade { Descricao = "Pirambu" },
                        new Cidade { Descricao = "Poço Redondo" },
                        new Cidade { Descricao = "Poço Verde" },
                        new Cidade { Descricao = "Porto da Folha" },
                        new Cidade { Descricao = "Propriá" },
                        new Cidade { Descricao = "Riachão do Dantas" },
                        new Cidade { Descricao = "Riachuelo" },
                        new Cidade { Descricao = "Ribeirópolis" },
                        new Cidade { Descricao = "Rosário do Catete" },
                        new Cidade { Descricao = "Salgado" },
                        new Cidade { Descricao = "Samambaia (Tobias Barreto)" },
                        new Cidade { Descricao = "Santa Luzia do Itanhy" },
                        new Cidade { Descricao = "Santa Rosa de Lima" },
                        new Cidade { Descricao = "Santana do São Francisco" },
                        new Cidade { Descricao = "Santo Amaro das Brotas" },
                        new Cidade { Descricao = "São Cristóvão" },
                        new Cidade { Descricao = "São Domingos" },
                        new Cidade { Descricao = "São Francisco" },
                        new Cidade { Descricao = "São Mateus da Palestina (Gararu)" },
                        new Cidade { Descricao = "São Miguel do Aleixo" },
                        new Cidade { Descricao = "Simão Dias" },
                        new Cidade { Descricao = "Siriri" },
                        new Cidade { Descricao = "Telha" },
                        new Cidade { Descricao = "Tobias Barreto" },
                        new Cidade { Descricao = "Tomar do Geru" },
                        new Cidade { Descricao = "Umbaúba" },
                    }
                });
                _context.Estados.Add(new Estado { Descricao = "São Paulo", Sigla = "" });
                _context.Estados.Add(new Estado { Descricao = "Tocantins", Sigla = "" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task InserirUnidades()
        {
            if (!_context.Unidades.Any())
            {
                var unidade = new Unidade
                {
                    LogradouroId = _context.Logradouros.FirstOrDefault(x => x.CEP == "49097-000")!.Id,
                    CNES = "0002461",
                    Nome = "US Fernando Sampaio",
                    Numero = "986",
                    Complemento = "Castelo Branco",
                    ImovelTipo = ImovelTipo.UNIDADE_DE_SAUDE,
                    Latitude = 0.0,
                    Longitude = 0.0,
                    SemNumero = false,
                    Celular = "",
                    Telefone = "(79)3179-1095",
                    Email = "ubs.fernandosampaio@aracaju.se.gov.br",
                    PontoDeReferencia = "",
                    WhatsApp = "",
                    Areas = new List<Area>()
                {
                    new Area()
                    {
                        Descricao = "050",
                        Nome = "Eucalyptos",
                        INE = "0000172235",
                        Micros = new List<Micro>()
                        {
                            new Micro() { Descricao = "01"},
                            new Micro() { Descricao = "02"},
                            new Micro() { Descricao = "03"},
                            new Micro() { Descricao = "04"},
                            new Micro() { Descricao = "05"},
                        }
                    }
                }
                };

                await _context.Unidades.AddAsync(unidade);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<Usuario> VerificarUsuario(UsuarioTipo tipo, string nome, string sobrenome, string cpf, string cns, DateTime nascimento, Sexo sexo, string nomeDaFuncao)
        {
            var usuario = await _userManager.SelecionaUsuarioAsync(cpf);
            if (usuario != null)
            {
                usuario = new Usuario
                {
                    IsActive = true,
                    CPF = cpf,
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Nascimento = nascimento,
                    CNS = cns,
                    Sexo = sexo,
                    UserName = cpf,
                };

                await _userManager.AdicionarUsuarioAsync(usuario, "123456");
                await _userManager.AdicionarUsuarioParaFuncao(usuario, nomeDaFuncao);
            }

            return usuario!;
        }

        private async Task VerificarFuncoesAsync()
        {
            await _userManager.VerificarFuncaoAsync(FuncaoConstante.ACS);
            await _userManager.VerificarFuncaoAsync(FuncaoConstante.Administrador);
            await _userManager.VerificarFuncaoAsync(FuncaoConstante.Enfermeiro);
            await _userManager.VerificarFuncaoAsync(FuncaoConstante.Paciente);
            await _userManager.VerificarFuncaoAsync(FuncaoConstante.TecEnfermagem);
        }
    }
}
