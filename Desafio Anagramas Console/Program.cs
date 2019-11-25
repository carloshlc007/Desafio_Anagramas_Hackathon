using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagramas_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Digite uma palavra para verificar seus anagramas");
                var expressao = Console.ReadLine();
                expressao = GeradorAnagrama.pegaLetras(expressao);
                
                if (!GeradorAnagrama.ValidarLetras(expressao)) break;

                var result = GeradorAnagrama.GerarAnagramas(expressao);

               // Console.WriteLine(result.Count());
                MostrarAnagramas(result);

                Console.WriteLine("\n\nDeseja sair? digite S/N");
                var sair = Console.ReadLine();

                if (sair.ToUpper() == "S")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                }

            }

            Console.WriteLine("\n\nPressione qualquer tecla para finalizar a aplicação!!!");
            Console.ReadKey();
        }

        public static void MostrarAnagramas(List<string> resultados)
        {
            if (resultados.Count() <= 0)
            {
                Console.WriteLine("Nenhum anagramas encontrado para esta expressão!");
            }
            else
            {
                Console.WriteLine("Resultado da busca" + "(" + resultados.Count() + "):\n");
                foreach (var r in resultados)
                {
                    Console.WriteLine(r);
                }
            }
        }
    }
}
