using System;

namespace Questao_2
{
    class Questao_2
    {
        //o input de entrada pode ser um valor inteiro somente,ou os dois valores sendo passados separados por uma virgula ou um espaço apenas
        static void Main(string[] args)
        {
            try
            {
                Questao_2.Validar_input();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro nas funções estáticas." + ex.Message);
            }
        }
        //função responsável por validar o input do usuário e verificar se está de acordo com os requisitos do exercício
        static void Validar_input()
        {
            int num1 = 0;
            int num2 = 0;
            int quantidade_numeros = 2;//variável auxiliar para informar quantos numeros o usuário ainda deve digitar

            //loop para a leitura de dados do usuário, de modo que tal loop só irá ser quebrado quando os requisitos do problema forem atendidos
            while (true)
            {
                bool auxiliar_validacao = true; //variável auxiliar na verificação do input

                if (quantidade_numeros == 2)
                    Console.WriteLine("Escreva dois números inteiros pares: ");
                else
                    Console.WriteLine("Escreva mais um  número inteiro par: ");

                try
                {
                    string entrada = Console.ReadLine();

                    if (string.IsNullOrEmpty(entrada)) //verifica se o input passado é nulo ou vazio
                    {
                        Console.WriteLine("Entrada inválida, digite novamente: ");
                        continue;
                    }

                    for (int a = 0; a < entrada.Length; a++) //percorre a string passada como parametro para verificar se é um input válido
                    {
                        char auxiliar = entrada[a];

                        if (!char.IsDigit(auxiliar))//siginifica que o valor presente não é um valor entre 0-9, porem caracteres ',' ' '. são validos com algumas restrições
                        {

                            if ((a == 0) && (auxiliar == ',' || auxiliar == ' '))//significa que os caracteres ',' ' ', estão na primeira posiçao do vetor (EX: ,2,2)
                            {
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_validacao = false;
                                break;
                            }

                            if ((a == entrada.Length) && (auxiliar == ',' || auxiliar == ' '))//significa que os caracteres ',' ' ', estão na última posiçao do vetor (EX: 2,2,)
                            {
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_validacao = false;
                                break;
                            }

                            if (auxiliar == ' ' || auxiliar == ',')//caso no qual o usuário digita algo como 2,,2 ou 2  2
                            {
                                char auxiliar2 = entrada[a + 1];
                                if (char.IsDigit(auxiliar2))
                                    continue;//significa que o valor na frente do + é um número 

                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_validacao = false;
                                break;
                            }

                            if (auxiliar != ',' && auxiliar != ' ')//significa que o input apresenta algum caractere não válido
                            {
                                if (auxiliar == '+' && ((a + 1) < entrada.Length))//verificar input do usuário como por exemplo +4, indicando ser um número positivo
                                {
                                    char auxiliar2 = entrada[a + 1];
                                    if (char.IsDigit(auxiliar2))
                                        continue;//significa que o valor na frente do + é um número 
                                }

                                if (auxiliar == '-' && ((a + 1) < entrada.Length))//verificar numeros negativos
                                {
                                    char auxiliar2 = entrada[a + 1];
                                    if (char.IsDigit(auxiliar2))
                                        continue;//significa que o valor na frente do - é um número 
                                }
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_validacao = false;
                                break;
                            }
                        }
                    }

                    if (auxiliar_validacao) //significa que o input passou na primeira bateria de verificação, sendo esse um valor númerico
                    {

                        string[] partes = entrada.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if ((quantidade_numeros - partes.Length) < 0)// caso no qual o usuário digita os numeros em uma linha apenas(Ex. 2,2,3)
                        {
                            Console.WriteLine("Entrada inválida,o a quantidade de números deve ser no máximo 2 elementos; digite novamente: ");
                            continue;
                        }

                        //verificar se o input de entrada é um valor válido para um inteiro,
                        // pois um dos requisítos do problema era a entrada somente de numeros inteiros
                        for (int a = 0; a < partes.Length; a++)
                        {
                            try
                            {
                                // passa o avlor armazenado para uma variável do tipo long, 
                                //pois o valor long consegue armazenar um valor de até  9223372036854775807.
                                long numero_entrada = Convert.ToInt64(partes[a]);

                                if (numero_entrada > 2147483647) //significa que o input passado é maior que o valor suportado por um inteiro na arquitetura atual.
                                {
                                    Console.WriteLine("Numero passado ultrapassa o tamanho de um int, digite novamente:");
                                    auxiliar_validacao = false;
                                    break;
                                }
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("O número digitado é muito grande para ser convertido em um long.");
                                auxiliar_validacao = false;
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("A entrada não é um número válido.");
                                auxiliar_validacao = false;
                                break;
                            }
                        }

                        if (auxiliar_validacao)//chegado a esse ponto a entrada digitada pelo usuário é válida
                        {
                            for (int a = 0; a < partes.Length; a++)
                            {
                                if (quantidade_numeros == 2)
                                    num1 = Convert.ToInt32(partes[a]);
                                else
                                    num2 = Convert.ToInt32(partes[a]);

                                quantidade_numeros--;
                            }

                            if (quantidade_numeros == 0)
                                break; //números preenchidos com sucsso
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro, algum input inválido foi digitado, digite novamente: ");
                }
            }

            Questao_2.Multiplicacao(num1, num2);
            Questao_2.Divisao(num1, num2);
        }

        //função responsável por realizar a operação de multiplicação
        //como o exercicio não específicou qual numero ia ser multiplar irei realizar as duas
        // num1 x num1....ate chegar em num2 e num2xnum2...até chegar em num1
        static void Multiplicacao(int num1, int num2)
        {
            int multiplicacao_num1 = 0;
            int multiplicacao_num2 = 0;

            // Verifica se o resultado deve ser negativo
            bool resultadoNegativo = (num1 < 0 && num2 > 0) || (num1 > 0 && num2 < 0);

            int absNum1 = Math.Abs(num1);
            int absNum2 = Math.Abs(num2);

            for (int a = 0; a < absNum2; a++)
            {
                multiplicacao_num1 = multiplicacao_num1 + absNum1;
            }

            for (int a = 0; a < absNum1; a++)
            {
                multiplicacao_num2 = multiplicacao_num2 + absNum2;
            }

            // Ajusta o sinal do resultado
            if (resultadoNegativo)
            {
                multiplicacao_num1 = -multiplicacao_num1;
                multiplicacao_num2 = -multiplicacao_num2;
            }

            Console.WriteLine("Multiplica o valor num1 n vezes, onde n é num2: " + multiplicacao_num1);
            Console.WriteLine("Multiplica o valor num2 n vezes, onde n é num1: " + multiplicacao_num2);
        }
        //função responsável por realizar a divisão dos números 
        //como o exercicio não específicou qual numero ia ser multiplar irei realizar as duas
        // num1 / num1 e num2/num1
        static void Divisao(int num1, int num2)
        {
            // Verifica se o resultado deve ser negativo
            bool resultadoNegativo = (num1 < 0 && num2 > 0) || (num1 > 0 && num2 < 0);

            // Use Math.Abs para obter o valor absoluto dos números
            int absNum1 = Math.Abs(num1);
            int absNum2 = Math.Abs(num2);

            if (absNum1 == 0)
            {
                Console.WriteLine($"Divisão de {num1} por {num2}: 0");
                Console.WriteLine($"Divisão de {num2} por {num1}: Indefinida (num1 é zero).");
                return;
            }

            if (absNum2 == 0)
            {
                Console.WriteLine($"Divisão inteira de {num2} por {num1}: 0");
                Console.WriteLine($"Divisão inteira de {num1} por {num2}: Indefinida (num1 é zero).");
                return;
            }
            int resultado1 = 0;
            int resultado2 = 0;
            int tempNum1 = absNum1; // Use absNum1
            int tempNum2 = absNum2; // Use absNum2

            while (tempNum1 >= absNum2)
            {
                tempNum1 -= absNum2;
                resultado1++;
            }

            while (tempNum2 >= absNum1)
            {
                tempNum2 -= absNum1;
                resultado2++;
            }
            // Ajusta o sinal do resultado
            if (resultadoNegativo)
            {
                resultado1 = -resultado1;
                resultado2 = -resultado2;
            }
            Console.WriteLine($"Divisão de {num1} por {num2}: {resultado1}");
            Console.WriteLine($"Divisão de {num2} por {num1}: {resultado2}");
        }
    }
}
