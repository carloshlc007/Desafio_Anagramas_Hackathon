using System;
using System.Collections.Generic;
using System.IO;

namespace Anagramas_Console
{
    class GeradorAnagrama
    {
        string palavra;

        public GeradorAnagrama(string palavra)
        {
            this.palavra = palavra;
        }

        public static string pegaLetras(string palavra)
        {
            var p = palavra;
            p = p.Replace(" ", "");
            p = p.Replace(",", "");
            return p.ToUpper();
        }

        public static bool validarAnagramas(string palavra, string dicionario)
        {

            for (int i = 0; i < dicionario.Length - 1; i++)
            {
                int aux = palavra.IndexOf(palavra[i]);

                if (aux == -1)
                {
                    return false;
                }
                else
                {
                    palavra.Remove(aux, 1);
                }
            }

            return true;
        }

        public static bool ValidarLetras(string palavra)
        {
            bool validado = true;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (Char.Equals(palavra[i], ',') || Char.Equals(palavra[i], ' '))
                {
                    continue;
                }

                if (!Char.IsLetter(palavra[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Palavra com caracteres invalidos!!!");
                    Console.ResetColor();
                    validado = false;
                    break;
                }
            }

            if (validado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Palavra valida!!!");
                Console.ResetColor();
            }

            return validado;
        }
    
        public static string retirarLetrasDaExpressao(string expressao, string palavra)
        {
            for (int i = 0; i <= palavra.Length - 1; i++)
            {
                int x = expressao.IndexOf(palavra[i]);
                if (x != -1)
                {
                    expressao = expressao.Remove(x, 1);
                }
            }
            return expressao;
        }

        public static bool validarAnagrama(string expressao, string palavra)
        {
            for (int i = 0; i <= palavra.Length - 1; i++)
            {
                int x = expressao.IndexOf(palavra[i]);
                if (x == -1)
                {
                    return false;
                }
                else
                {
                    expressao = expressao.Remove(x, 1);
                }
            }

            return true;
        }

        public static List<string> GerarAnagramas(string expressao)
        {
            try
            {
                string expressaoTemp = null;
                string expressaoVal = null;
                List<string> palavrasValidas = new List<string>();

                string[] dicionario = File.ReadAllLines("Palavras.txt");

                //Percorre as dicionario da lista
                for (int i = 0; i < dicionario.Length; i++)
                {
                    List<string> possiveisAnagramas = new List<string>();
                    expressaoTemp = expressao;

                    //Verifica se a palavra é um possível GeradorAnagrama para a expressão
                    if (GeradorAnagrama.validarAnagrama(expressaoTemp, dicionario[i]))
                    {
                        possiveisAnagramas.Add(dicionario[i]);
                        expressaoTemp = GeradorAnagrama.retirarLetrasDaExpressao(expressaoTemp, dicionario[i]);
                        expressaoVal = expressaoTemp;
                        int tentativa = 0;

                        //Procura outras dicionario para completar o Anagrama
                        for (int j = i; j < dicionario.Length; j++)
                        {
                            if (dicionario[j] != dicionario[i])
                            {
                                //Verifica se é uma possível combinação para Gerador Anagrama
                                if (GeradorAnagrama.validarAnagrama(expressaoVal, dicionario[j]))
                                {

                                    //Registra a linha da tentativa para não repetir
                                    if (tentativa == 0)
                                    {
                                        tentativa = j;
                                    }

                                    possiveisAnagramas.Add(dicionario[j]);
                                    expressaoVal = GeradorAnagrama.retirarLetrasDaExpressao(expressaoVal, dicionario[j]);

                                    //Verifica se for feito um Anagrama
                                    if (expressaoVal.Length == 0)
                                    {
                                        //Adiciona GeradorAnagrama na lista de anagramas válidos
                                        string anagramasStr = string.Join(" ", possiveisAnagramas);
                                        palavrasValidas.Add(anagramasStr);

                                        possiveisAnagramas.RemoveRange(1, possiveisAnagramas.Count - 1);
                                        expressaoVal = expressaoTemp;
                                        j = tentativa + 1;
                                        tentativa = 0;
                                    }
                                }
                                //Verifica se todas as combinações foram feitas e tenta novamente com outras palavras do dicionario
                                if (j + 1 == dicionario.Length && possiveisAnagramas.Count > 1)
                                {
                                    possiveisAnagramas.RemoveRange(1, possiveisAnagramas.Count - 1);
                                    expressaoVal = expressaoTemp;
                                    j = tentativa + 1;
                                    tentativa = 0;
                                }
                            }
                        }
                    }
                }
                return palavrasValidas;
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
