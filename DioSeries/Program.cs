﻿using DioSeries;
using DioSeries.Enum;
using static System.Console;

class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();
        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                VisualizarSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
        WriteLine("Obrigado por utilizar nossos serviços.");
        ReadLine();
    }
    private static void ExcluirSerie()
    {
        Write("Digite o id  para excluir: ");
        int indiceSerie = int.Parse(ReadLine());


        repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie()
    {
        Console.Write("Digite o id que deseja visualizar: ");
        int indiceSerie = int.Parse(ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        WriteLine(serie);
    }

    private static void AtualizarSerie()
    {
        Write("Digite o id da série para atualizar: ");
        int indiceSerie = int.Parse(ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Write("Digite o numero do gênero entre as opções acima: ");
        int entradaGenero = int.Parse(ReadLine());

        Write("Digite o Título da Série: ");
        string entradaTitulo = ReadLine();

        Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(ReadLine());

        Write("Digite a Descrição da Série: ");
        string entradaDescricao = ReadLine();

        Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero,
        titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

        repositorio.Atualizar(indiceSerie, atualizaSerie);
    }
    private static void InserirSerie()
    {
        WriteLine("Inserir nova série");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(ReadLine());

        Write("Digite o Título da Série: ");
        string entradaTitulo = ReadLine();

        Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(ReadLine());

        Write("Digite a Descrição da Série: ");
        string entradaDescricao = ReadLine();

        Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
        titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
    }
    private static void ListarSeries()
    {
        WriteLine("Listar série");
        var lista = repositorio.Lista();
        if (lista.Count == 0)
        {
            WriteLine("Nenhuma série cadastrada.");
            return;
        }
        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();
            WriteLine("ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), 
            (excluido ? "Está série foi excluida" : ""));
        }
    }

    private static string ObterOpcaoUsuario()
    {
        WriteLine();
        WriteLine("Dio Séries a seu dispor!!!");
        WriteLine("Informe a opção desejada:");

        WriteLine("1- Listar séries");
        WriteLine("2- Inserir nova série");
        WriteLine("3- Atualizar série");
        WriteLine("4- Excluir série");
        WriteLine("5- Visualizar série");
        WriteLine("C- Limpar tela");
        WriteLine("X- Sair");
        WriteLine();

        string opcaoUsuario = ReadLine().ToUpper();
        WriteLine();
        return opcaoUsuario;
    }
}
