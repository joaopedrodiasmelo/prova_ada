using System;

namespace questao_4
{
    class questao_4
    {
        static void Main(string[] args)
        {
            try
            {
                Int32 numero;
                numero = Convert.ToInt16(!(21 > 21));
                Console.WriteLine(numero);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro nas funções estáticas." + ex.Message);
            }
        }

    }

    //Justificação do exercício

    // A expressão dentro do Convert.ToInt16 é !(21 > 21). Esta expressão 21 >
    // 21 avalia se 21 é maior do que 21, o que é falso (pois eles são iguais). 
    //Então, o operador de negação lógica ! inverte esse valor para verdadeiro (true). 
    //Portanto, o valor atribuído à variável numero é true, que é convertido para 1 ao chamar Convert.
    //ToInt16, mas então você usa Convert.ToInt16, que converte o valor 1 para um número de 16 bits (Int16), resultando em 1.
    //Então, o código irá imprimir 1 no console. Portanto, a resposta correta é C) 1.
    //Em termos gerais essa reposta segue a mesma lógica de sistemas de lógica digital onde o valor 1 representa true e o 0 falso
}
