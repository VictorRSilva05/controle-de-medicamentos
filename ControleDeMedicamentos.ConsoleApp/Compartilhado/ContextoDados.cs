using System.Text.Json;
using System.Text.Json.Serialization;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class ContextoDados
    {
        private string pastaArmazenamento = "C:\\temp";
        private string arquivoArmazenamento = "dados_medicamentos.json";

        //public List<Paciente> pacientes { get; set; }

        public ContextoDados()
        {
            //pacientes = new List<Paciente>();
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

            if(!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminhoCompleto, json);
        }

        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (File.Exists(caminhoCompleto))
                return;

            string json = File.ReadAllText(caminhoCompleto);

            if (string.IsNullOrWhiteSpace(json))
                return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(json, jsonOptions);

            if (contextoArmazenado == null)
                return;

            //this.Pacientes = contextoArmazenado.Pacientes;
        }
    }
}
