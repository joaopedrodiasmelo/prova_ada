using System;

namespace Questao_3
{
    class Questao_3
    {
        //o input pode ser uma frase que pertença a lingaugem natural , letras e espaços em branco apenas
        static void Main(string[] args)
        {
            try
            {
                Questao_3.Validar_input();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro nas funções estáticas." + ex.Message);
            }
        }
        //função responsável por receber a entrada do usuário e realizar as validações do input
        static void Validar_input()
        {
            int quantidade_de_caracteres = 0;
            int quant_maiusculas = 0;
            int quant_minusculas = 0;
            int iniciam_minusculas = 0;
            int iniciam_maiusculas = 0;
            char[] caracteresEspeciais = { '$', '@', '#', '%', '&', '!', '(', ')' }; // Adicione os caracteres especiais desejados


            try
            {
                while (true)
                {
                    Console.WriteLine("insira um frase, em linguagem natural, ou seja  letra ou espaço em branco: ");
                    string entrada = Console.ReadLine();
                    bool auxiliar_verificacao = true;//variável auxiliar na validação do input

                    if (string.IsNullOrEmpty(entrada)) //verifica se a string é nula ou vazia
                    {
                        Console.WriteLine("Valor incorreto,digite novamente:  ");
                        continue;
                    }

                    for (int a = 0; a < entrada.Length; a++) //percorre a string entrada para verificar se é uma string válida
                    {
                        char auxiliar = entrada[a];

                        if (char.IsDigit(auxiliar))
                        {
                            Console.WriteLine("Valor incorreto,digite novamente:  ");
                            auxiliar_verificacao = false;
                            break;
                        }
                        //caso apos o ' ', deve realizar apenas um para separar as palavras
                        if (auxiliar == ' ' && ((a + 1) < entrada.Length))//caso no qual o usuário digita algo como joao  . mais de dois espaços
                        {

                            char auxiliar2 = entrada[a + 1];//o valor da frente deve ser necessariamente uma letra
                            if (char.IsWhiteSpace(auxiliar2))
                            {
                                Console.WriteLine("Entrada inválida, digite novamente:  ");
                                auxiliar_verificacao = false;
                                break;
                            }
                            if (caracteresEspeciais.Contains(auxiliar))
                            {
                                Console.WriteLine("Caractere especial encontrado.");
                                auxiliar_verificacao = false;
                                break;
                            }
                            if (char.IsDigit(auxiliar))
                            {
                                Console.WriteLine("Valor incorreto,digite novamente:  ");
                                auxiliar_verificacao = false;
                                break;
                            }
                        }
                        if (caracteresEspeciais.Contains(auxiliar))
                        {
                            Console.WriteLine("Caractere especial encontrado.");
                            auxiliar_verificacao = false;
                            break;
                        }

                    }
                    if (auxiliar_verificacao)
                    {
                        for (int a = 0; a < entrada.Length; a++)
                        {
                            char auxiliar2 = entrada[a];
                            quantidade_de_caracteres++;
                            if (char.IsUpper(auxiliar2))
                            {
                                quant_maiusculas++;
                                continue;
                            }
                            if (char.IsLower(auxiliar2))
                            {
                                quant_minusculas++;
                                continue;
                            }
                        }

                        //subdivisão da string para contar quantas palavras comceçam com a letra maiuscula
                        string[] partes = entrada.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int a = 0; a < partes.Length; a++)
                        {
                            char first_char = partes[a][0];

                            if (char.IsUpper(first_char))
                                iniciam_maiusculas++;
                            else
                                iniciam_minusculas++;
                        }

                        break;//quebra o while
                    }
                }
                Console.WriteLine("Quantidade de palavras maiusculas: " + quant_maiusculas);
                Console.WriteLine("Quantidade de palavras minusculas: " + quant_minusculas);
                Console.WriteLine("Quantidade de palavras que iniciam com letra maiuscula: " + iniciam_maiusculas);
                Console.WriteLine("Quantidade de palavras que iniciam com letra minuscula: " + iniciam_minusculas);
                Console.WriteLine("Quantidade de palavras digitadas: " + quantidade_de_caracteres);
            }
            catch (Exception)
            {
                Console.WriteLine("Erro, algum input inválido foi digitado, digite novamente: ");
            }
        }
    }
}