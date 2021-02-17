using System;
using Series.Classes;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
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
                        ExcluiSerie();
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
                opcao = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossa plataforma e volte sempre!!");
            Console.ReadLine();


        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seriados ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar series");
            Console.WriteLine("4 - Escluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
        public static void ListarSeries()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var serieExcluida = serie.retornaExcluido(); 
                if(serieExcluida){

                }
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), serieExcluida ? "Excluido" : "");
            }
        }

        public static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero dentre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a descricao da série");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série");
            int ano = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(Id: repositorio.ProximoId(),
                                        genero: (Genero)genero,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);
            repositorio.Inserir(novaSerie);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int id = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(id);

            Console.WriteLine(serie);
        }

        private static void ExcluiSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int id = int.Parse(Console.ReadLine());

            repositorio.Excluir(id);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Qual id desejas atualizar?");
            int id = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero dentre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a descricao da série");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série");
            int ano = int.Parse(Console.ReadLine());

            Serie atualizaSeriado = new Serie(Id: id,
                                              genero: (Genero) genero,
                                              titulo: titulo,
                                              descricao: descricao,
                                              ano: ano);
            repositorio.Atualizar(id, atualizaSeriado);                                  
        }
    }
}
