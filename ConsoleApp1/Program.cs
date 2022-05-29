using ConsoleApp1.ENUM;
using ConsoleApp1.Model;
using ConsoleApp1.Repository;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static SerieRepository serieRepository = new SerieRepository();
        static void Main(string[] args)
        { 
            menu(); 
        }

        static void menu() {
            bool continuar = true;
            do {
            Console.WriteLine("Escreva a opção desejada");
            Console.WriteLine("1- listar");
            Console.WriteLine("2- encontrar serie por id");
            Console.WriteLine("3- deletar serie");
            Console.WriteLine("4- inserir nova serie");
            Console.WriteLine("5- atualizar");
            Console.WriteLine("X- Sair");
                var escolha = Console.ReadLine();
     switch (escolha)
                {
                    case "1":
                        //listar OK
                        List<Serie> series = serieRepository.listar();
                        if (series.Count <= 0)
                        {
                            Console.WriteLine("Não existem series");
                        }
                        foreach (var serie1 in series )
                        {
                           Console.WriteLine(serie1.ToString());
                        }
                        
                        break;
                    case "2":
                        //encontar serie por id
                        Console.WriteLine("Insira o id");
                        var id = int.Parse(Console.ReadLine());
                        Serie? encontrada = serieRepository.FindByID(id);
                        if (encontrada == null)
                        {
                            Console.WriteLine("Serie Não achada brow, fé");
                        }
                        else Console.WriteLine(encontrada.ToString());

                        break;
                    case "3":
                        //deletar serie
                        Console.WriteLine("insira o id");
                        var id3 = int.Parse(Console.ReadLine());
                        serieRepository.DeleteById(id3);
                        break;
                    case "4":
                        //inserir nova serie
                        //assim pegamos um array dos enums
                        foreach (int i in Enum.GetValues(typeof(Categorias)))
                        {
                            Console.WriteLine($"indice: {i}- Categoria: {Enum.GetName(typeof(Categorias), i)}");
                        }
                        Console.WriteLine("insira uma das categorias acima");
                        int enumN = int.Parse(Console.ReadLine());

                        Console.WriteLine("insira o titulo");
                        string titulo = Console.ReadLine();

                        Console.WriteLine("insira a descrição");
                        string desc = Console.ReadLine();

                        Console.WriteLine("insira o ano");
                        int ano = int.Parse(Console.ReadLine());
                        Serie serie = new Serie(
                            id: serieRepository.ProximoID(),
                            categorias: (Categorias)enumN,
                            titulo: titulo,
                            descricao: desc,
                            ano: ano);
                        serieRepository.Save(serie);

                        break;
                    case "5":
                        //Atualizar
                        Console.WriteLine("Qual deseja modificar?");
                        var idnovo = int.Parse(Console.ReadLine());
                        Serie? serieAntiga = serieRepository.FindByID(idnovo);
                        if (serieAntiga == null)
                        {
                            Console.WriteLine("Serie Não achada brow, fé");
                            menu();
                        }
                        
                        else Console.WriteLine($"Serie antiga: {serieAntiga.ToString()}");

                        foreach (int i in Enum.GetValues(typeof(Categorias)))
                        {
                            Console.WriteLine($"indice: {i}- Categoria: {Enum.GetName(typeof(Categorias), i)}");
                        }
                        Console.WriteLine("insira uma das categorias acima");
                        int enumNAtualizar = int.Parse(Console.ReadLine());

                        Console.WriteLine("insira o titulo");
                        string tituloAtualizar = Console.ReadLine();

                        Console.WriteLine("insira a descrição");
                        string descAtualizar = Console.ReadLine();

                        Console.WriteLine("insira o ano");
                        int anoAtualizar = int.Parse(Console.ReadLine());
                        Serie serieAtualizar = new Serie(
                            id: idnovo,
                            categorias: (Categorias)enumNAtualizar,
                            titulo: tituloAtualizar,
                            descricao: descAtualizar,
                            ano: anoAtualizar);
                        serieRepository.Update(idnovo,serieAtualizar);
                        break;
                    case "X":
                        Console.WriteLine("Até mais");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("escreva uma opção valida");
                        break;

                }
            } while (continuar == true);

           
        }
    
        static bool lerid(int id)
    {
        if (id>serieRepository.ProximoID())
        {
                Console.WriteLine("Id não existe");
                return false;
        }
            return true;
    }

       
    }
}