using System;

namespace questao_4
{
    class questao_4
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = -5; i <= 7; i += 3)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro nas funções estáticas." + ex.Message);
            }
        }

    }
    //Justificação do exercício

    // O loop começa com "i" em -5.
    // Primeira iteração: "i" permanece -5 e é impresso.
    // Segunda iteração: "i" é incrementado em 3, tornando-se -2, e é impresso.
    // Terceira iteração: "i" é incrementado em 3, tornando-se 1, e é impresso.
    // Quarta iteração: "i" é incrementado em 3, tornando-se 4, e é impresso.
    // Quinta iteração: "i" é incrementado em 3, tornando-se 7. 
    // Neste ponto, o loop para porque a condição "i <= 7" não é mais verdadeira.

    // Portanto, a sequência de números impressa será: -5, -2, 1, 4, 7.

}

