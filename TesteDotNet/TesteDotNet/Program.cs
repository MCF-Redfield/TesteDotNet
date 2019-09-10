using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            string[] nums ;
            string sentence;
            double resultado;
            string operacao;
            List<string> numeros; ;
            Service service = new Service();
            Operacoes op = new Operacoes();

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\tSeja bem vindo!!!\t");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Informe a operação:");
                Console.WriteLine("\t + Soma\t");
                Console.WriteLine("\t - Subtração\t");
                Console.WriteLine("\t / Divisão\t");
                Console.WriteLine("\t * Multiplicação\t");
                Console.WriteLine("\t @ Calcula Média\t");
                Console.WriteLine("\t $ Soma de N Números\t");
                Console.WriteLine("\t ! Soma Pares\t");
                Console.WriteLine("\t & Ler Arquivo\t");
                Console.WriteLine("\t # Sentença Personalizada('operacao;num1;num2')\t");
                operacao = Console.ReadLine();
                Console.Clear();

                /* Como eh para tratar as excecoes dentro das operações, vou ler
                 * e passa-las como string ao invés de le-las como double e 
                 * valida-las antes de passar para as operações*/

                switch (operacao)
                {
                    case "+":
                        service.DestacaBackground("\t+ Soma\t\n");
                        nums = service.Ler2Numeros();
                        try
                        {
                            resultado = double.Parse(op.Somar(nums[0], nums[1]));
                            service.DestacaBackground("Resultado: " + resultado);
                        }
                        catch
                        {
                            service.ExibeErro("Valores invalidos (" + nums[0] + "," + nums[1] + ") p/ realizar a operacao de Soma!");
                        }
                        break;

                    case "-":
                        service.DestacaBackground("\t- Subtração\t\n");
                        nums = service.Ler2Numeros();
                        try
                        {
                            resultado = double.Parse(op.Subtrair(nums[0], nums[1]));
                            service.DestacaBackground("Resultado: " + resultado);
                        }
                        catch
                        {
                            service.ExibeErro("Valores invalidos (" + nums[0] + "," + nums[1] + ") p/ realizar a operacao de Subtração!");
                        }
                        break;

                    case "*":
                        service.DestacaBackground("\t* Multiplicação\t\n");
                        nums = service.Ler2Numeros();
                        try
                        {
                            resultado = double.Parse(op.Multiplicar(nums[0], nums[1]));
                            service.DestacaBackground("Resultado: " + resultado);
                        }
                        catch
                        {
                            service.ExibeErro("Valores invalidos (" + nums[0] + "," + nums[1] + ") p/ realizar a operacao de Multiplicação!");
                        }
                        break;

                    case "/":
                        service.DestacaBackground("\t+ Divisão\t\n");
                        nums = service.Ler2Numeros();
                        try
                        {
                            resultado = double.Parse(op.Dividir(nums[0], nums[1]));
                            service.DestacaBackground("Resultado: " + resultado);
                        }
                        catch
                        {
                            service.ExibeErro("Valores invalidos (" + nums[0] + "," + nums[1] + ") p/ realizar a operacao de Divisão!");
                        }
                        break;

                    case "#":
                        service.DestacaBackground("\t# Sentença Personalizada\t\n");
                        Console.WriteLine("Digite o argumento nesse formato 'operacao;num1;num2': ");
                        sentence = Console.ReadLine();
                        if (op.SentecaPersonalizada(sentence).Equals("error"))
                        {
                            service.ExibeErro("Formato Inválido!");
                        }
                        else
                        {
                            service.DestacaBackground("Resultado: " + op.SentecaPersonalizada(sentence));
                        }
                        break;

                    case "$":
                        service.DestacaBackground("\t$ Soma N Números\t\n");
                        numeros = service.LerNNumeros();
                        try
                        {
                            resultado = double.Parse(op.Somar(numeros));
                            service.DestacaBackground("Resultado: " + resultado);
                        }
                        catch
                        {
                            service.ExibeErro("Valores inválidos! Insira somente números");
                        }
                        break;

                    case "@":
                        service.DestacaBackground("\t@ Calcula Média\t\t\n");
                        numeros = service.LerNNumeros();
                        try
                        {
                            resultado = double.Parse(op.MediaNumeros(numeros));
                            service.DestacaBackground("Resultado: " + resultado);
                        }
                        catch
                        {
                            service.ExibeErro("Valores inválidos! Insira somente números");
                        }
                        break;

                    case "!":
                        service.DestacaBackground("\t! Soma Pares\t\n");
                        numeros = service.LerNNumeros();
                        try
                        {
                            resultado = double.Parse(op.SomarOnlyPares(numeros));
                            service.DestacaBackground("Resultado: " + resultado);
                        }
                        catch
                        {
                            service.ExibeErro("Valores inválidos! Insira somente números");
                        }
                        break;

                    case "&":
                        service.DestacaBackground("\t& Ler Arquivo\t\n");
                        op.CriarDicionario();
                        break;

                    default:
                        service.ExibeErro("Informe um operador válido!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar ou ESC para sair");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("\nObrigado por utilizar nossa calculadora!");
            await Task.Delay(3000);
        }
    }
}
