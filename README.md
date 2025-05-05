# ControleDeMedicamentos

![Controle De Medicamentos](https://i.imgur.com/rt0n0bi.gif)


## Introdução
Se você está precisando de algo para gerenciar o estoque dos seus medicamentos, gerenciar
prescrições médicas, etc... É exatamente aqui que você pode encontrar esse programa.

Permitindo que você gerencie com precisão seus medicamentos, pacientes, prescrições.
Armazenando as informações no seu próprio computador com arquivos Json.

## Como Usar
1. Menu principal contém as seguintes opções:
   - *Gerenciar Fornecedores:*
      - Cadastrar Fornecedor
      - Editar Fornecedor
      - Excluir Fornecedor
      - Visualizar Fornecedores
   - *Gerenciar Funcionários:* 
      - Registrar Funcionário
      - Editar Funcionário
      - Excluir Funcionário
      - Visualizar Funcionários
   - *Gerenciar Medicamentos:*
      - Registrar Medicamento
      - Editar Medicamento
      - Excluir Medicamento
      - Visualizar Medicamentos
   - *Gerenciar Pacientes:*
      - Registrar Paciente
      - Editar Paciente
      - Excluir Paciente
      - Visualizar Pacientes
   - *Gerenciar Prescrições Médicas:*
      - Registrar Prescrições Médica
      - Editar Prescrições Médica
      - Excluir Prescrições Médica
      - Visualizar Prescrições Médicas
   - *Gerenciar Requisições de entrada e saída:*
      - Registrar Requisições de entrada e saída
      - Editar ambos os tipos
      - Excluir ambos os tipos
      - Visualizar ambos os tipos

Os dados são validados para garantia de que estão corretos

## Requisitos

- .NET 9.0 para compilação e execução do projeto.

## Funcionalidades

- Não permite cadastro de pacientes com CNPJ igual ao já cadastrado;
- Não permite cadastrar pacientes com o mesmo cartão SUS;
- Destaca medicamentos, declarando se estão "Em Falta" ou "Disponível";
- Atualiza automaticamente a quantidade de medicamentos caso seja cadastrado com mesmo nome;
- Não permite que requisições excedam o estoque disponível;
- Subtrai automaticamente a quantidade de estoque ao registrar a requisição;
- Valida a disponibilidade dos medicamentos no estoque;
- Alerta quando a prescrição excede os limites permitidos;
- Exige prescrição válida para requisições de saída;
- Armazena os dados em arquivos Json.
 
## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=git,github,visualstudio,cs,dotnet)](https://skillicons.dev)

## Como Utilizar
1. *Clone o Repositório:*
```
git clone https://github.com/P-S-T-Partido-Socialista-do-Thiagao/ControleDeMedicamentos
```

2. Abra o terminal ou prompt de comando e navegue até a pasta raiz do programa.

3. Utilize o comando abaixo para restaurar as dependências do projeto.
```
dotnet restore
```

4. Compile e execute

- Executar o projeto compilando em tempo real
```
dotnet run --project ControleDeMedicamentos
```

# Sobre o Projeto

Este projeto foi desenvolvido como parte de um trabalho da [Academia do Programador](https://www.instagram.com/academiadoprogramador/).
