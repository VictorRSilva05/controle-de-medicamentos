namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase<TEntidade>
{
    private TEntidade[] registros = new TEntidade[100];
    private int contadorIds = 0;

    public void CadastrarRegistro(TEntidade novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        InserirRegistro(novoRegistro);
    }

    public bool EditarRegistro(int idRegistro, TEntidade registroEditado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].Id == idRegistro)
            {
                registros[i].AtualizarRegistro(registroEditado);

                return true;
            }
        }

        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].Id == idRegistro)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }

    public TEntidade[] SelecionarRegistros()
    {
        return registros;
    }

    public TEntidade SelecionarRegistroPorId(int idRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            TEntidade e = registros[i];

            if (e == null)
                continue;

            else if (e.Id == idRegistro)
                return e;
        }

        return null;
    }

    private void InserirRegistro(TEntidade registro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = registro;
                return;
            }
        }
    }
}
