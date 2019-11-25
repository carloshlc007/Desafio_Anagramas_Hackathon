using System;
using System.Collections.Generic;
using System.IO;

namespace Anagramas_Console
{
    class Dicionario
    {

       // public static string[] myDicionario = File.ReadAllLines("%dicionario%\\Palavras.txt");

        public static List<string> DescobrirAnagramas(string palavra)
        {
            try
            {
                //string palavraTemp = null;
                //string palavraValida = null;

                List<string> anagramasDescobertos = new List<string>();

                return anagramasDescobertos;

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro detectado!!!!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e);
                Console.ResetColor();
                throw;
            }
        }
    }
}
