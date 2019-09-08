using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = null;
            string num2 = null;
            string sentence = null;
            double resultado;
            string operacao;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Seja bem vindo!!!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
                        
            Console.WriteLine("Informe a operação:");
            Console.WriteLine(" + Soma");
            Console.WriteLine(" - Subtração");
            Console.WriteLine(" / Divisão");
            Console.WriteLine(" * Multiplicação");
            Console.WriteLine(" # Inserir sentenca manualmente('operacao;num1;num2')");
            operacao = Console.ReadLine();

            if (!operacao.Equals("+") &&
               !operacao.Equals("-") &&
               !operacao.Equals("/") &&
               !operacao.Equals("*") &&
               !operacao.Equals("#"))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Informe um operador válido!");
                Console.BackgroundColor = ConsoleColor.Black;
            }

            else if (operacao.Equals("#"))
            {
                Console.WriteLine("Digite o argumento nesse formato 'operacao;num1;num2': ");
                sentence = Console.ReadLine();
            }
            else
            {
                /* Como eh para tratar as excecoes dentro das operações, vou ler
                 * e passa-las como string ao invés de valida-las antes de passar
                 * para as operações*/

                Console.WriteLine("Digite o primeiro numero: ");
                num1 = Console.ReadLine();
                Console.WriteLine("Digite o segundo numero: ");
                num2 = Console.ReadLine();
            }
                Operacoes op = new Operacoes();
                
                switch (operacao)
                {
                    case "+":
                        resultado = double.Parse(op.Somar(num1, num2));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(resultado);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White; 
                        break;

                    case "-":
                        resultado = double.Parse(op.Subtrair(num1, num2));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(resultado);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White; 
                        break;
                        
                    case "*":
                        resultado = double.Parse(op.Multiplicar(num1, num2));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(resultado);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White; 
                        break;

                    case "/":
                        resultado = double.Parse(op.Dividir(num1, num2));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(resultado);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White; 
                        break;

                    case "#":
                        if(op.SentecaPersonalizada(sentence).Equals("error"))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Formato Inválido!");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Resultado: " + op.SentecaPersonalizada(sentence));
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    break;
            } 
        }
    }
}
