using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class ContextoDados
    {
        private string pastaArmazenamento = "C:\\Temp";
        private string arquivoArmazenamento = "dados_medicamentos.json";

        public List<Funcionario> Funcionarios { get; set; }
        public List<Fornecedor> Fornecedores { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
        public List<RequisicaoDeEntrada> RequisicoesDeEntrada { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public ContextoDados()
        {
            Fornecedores = new List<Fornecedor>();
            Funcionarios = new List<Funcionario>();
            Medicamentos = new List<Medicamento>();
            RequisicoesDeEntrada = new List<RequisicaoDeEntrada>();
            Pacientes = new List<Paciente>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                Carregar();
        }

        public void Salvar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            jsonSerializerOptions.WriteIndented = true;

            string json = JsonSerializer.Serialize(this, jsonSerializerOptions);

            if (!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminhoCompleto, json);
        }

        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (!File.Exists(caminhoCompleto))
                return;

            string json = File.ReadAllText(caminhoCompleto);

            if (string.IsNullOrWhiteSpace(json))
                return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(json, jsonOptions);

            if (contextoArmazenado == null)
                return;

            Fornecedores = contextoArmazenado.Fornecedores;
            Funcionarios = contextoArmazenado.Funcionarios;
            Medicamentos = contextoArmazenado.Medicamentos;
            RequisicoesDeEntrada = contextoArmazenado.RequisicoesDeEntrada;
            Pacientes = contextoArmazenado.Pacientes;
        }
    }
}
