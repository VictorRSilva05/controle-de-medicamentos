namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;
public abstract class EntidadeBase<TEntidade> : Object
{
    public int Id { get; set; }
    public abstract void AtualizarRegistro(TEntidade registroEditado);
    public abstract string Validar();
}