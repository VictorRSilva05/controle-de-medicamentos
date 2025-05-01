using ControleDeMedicamentos.ConsoleApp.Compartilhado;
public class TelaPrincipal
{
    public char opcaoPrincipal;  

    //private RepositorioDono repositorioDono;
    //private TelaDono telaDono;

    //private RepositorioPet repositorioPet;
    //private TelaPet telaPet;   

    public TelaPrincipal()
    {
        /*
        repositorioDono = new RepositorioDono();
        Dono novoDono = new Dono("Gabriel Velho");
        repositorioDono.CadastrarRegistro(novoDono);

        telaDono = new TelaDono("Dono", repositorioDono);

        repositorioPet = new RepositorioPet();
        repositorioPet.CadastrarRegistro(new Pet("Bob", novoDono));

        telaPet = new TelaPet("Pet", repositorioPet, telaDono, repositorioDono);
        */
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|       Gestão de Medicamentos         |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Donos");
        Console.WriteLine("2 - Cadastro de Pets");
       
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        EscolhoerOpcao();
    }

    public ITelaCrud ObterTela()
    {
        /*
        if (opcaoPrincipal == '1')
            return telaDono;

        else if (opcaoPrincipal == '2')
            return telaPet;
         */
        return null;
 
    }

    private void EscolhoerOpcao()
    {
        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()[0];
    }
}