﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class RepositorioMedicamentoEmArquivo : RepositorioBaseEmArquivo<Medicamento>, IRepositorioMedicamento
{
    public RepositorioMedicamentoEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }
    protected override List<Medicamento> ObterRegistros()
    {
        return contexto.Medicamentos;
    }
    protected override bool VerificarRegistroExistente(Medicamento registro)
    {
        return false;
    }

}

