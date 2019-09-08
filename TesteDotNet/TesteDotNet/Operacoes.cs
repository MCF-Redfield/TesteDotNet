using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet
{
    class Operacoes
    {
        Service service = new Service();

        public Operacoes()
        { }
        /* As funções deverão retornar os resultados(questão 03) e também informar
         * caso não seja possível realizar os calculos(questão 04). Sendo assim,
         * irei retornar no formato string, que me permitirá retornar qualquer texto.
         * Se deixasse para retornar Double, eu teria de retornar um numero mesmo
         * que não fosse possível realizar o calculo*/
        public string Somar(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) + double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Valores invalidos ({0},{1}) p/ realizar a operacao de Soma!", num1, num2);
                Console.BackgroundColor = ConsoleColor.Black;
                return "FormatException";
            }
        }
        public string Subtrair(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) - double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Valores invalidos ({0},{1}) p/ realizar a operacao de Subtração!", num1, num2);
                Console.BackgroundColor = ConsoleColor.Black;
                return "FormatException";
            }
        }
        public string Dividir(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) / double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Valores inválidos ({0},{1}) p/ realizar a operacao de Divisão!", num1, num2);
                Console.BackgroundColor = ConsoleColor.Black;
                return "FormatException";
            }
        }
        public string Multiplicar(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) * double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Valores invalidos ({0},{1}) p/ realizar a operacao de Multiplicação!", num1, num2);
                Console.BackgroundColor = ConsoleColor.Black;
                return "FormatException";
            }
        }
        public string SentecaPersonalizada(string sentence)
        {
            if (service.ValidaSentenca(sentence) == true)
            {
                List<int> posicaoPV = service.PosicaoPV(sentence);
                List<int> numerosSentence = service.Numeros(sentence, posicaoPV);
                string operacao = service.GetOperacao(sentence);
                string resultado = "error";
                
                switch (operacao)
                {
                    case "soma":
                        resultado = Somar("" + numerosSentence[0], "" + numerosSentence[1]);
                        break;
                    case "subtracao":
                        resultado = Subtrair("" + numerosSentence[0], "" + numerosSentence[1]);
                        break;
                    case "divisao":
                        resultado = Dividir("" + numerosSentence[0], "" + numerosSentence[1]);
                        break;
                    case "multiplicacao":
                        resultado = Multiplicar("" + numerosSentence[0], "" + numerosSentence[1]);
                        break;
                }
                return resultado;
            }
            else
            {
                return "error";
            }
        }

    }
        
}
