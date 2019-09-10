using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet
{
    class Service
    {
        public Service()
        { }

        //método que percorre a sentença e verifica qual a operação matemática
        public string GetOperacao(string sentence)
        {
            if (sentence.StartsWith("soma", System.StringComparison.CurrentCultureIgnoreCase))
                return "soma";
            if (sentence.StartsWith("subtracao", System.StringComparison.CurrentCultureIgnoreCase))
                return "subtracao";
            if (sentence.StartsWith("multiplicacao", System.StringComparison.CurrentCultureIgnoreCase))
                return "multiplicacao";
            if (sentence.StartsWith("divisao", System.StringComparison.CurrentCultureIgnoreCase))
                return "divisao";

            return "error";
        }

        //Método p/ armazenar a posição de cada ';'
        public List<int> PosicaoPV(string sentence)
        {
            List<int> qtdePV = new List<int>();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i].Equals(';'))
                {
                    qtdePV.Add(i);
                }
            }
            return qtdePV;
        }

        //Método p/ verificar se o ultimo caracter da sentença é um numero
        public bool VerificaUltimoElem(string sentence)
        {
            try
            {
                int num = int.Parse(""+sentence[sentence.Length-1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("lants in § " + sentence.Length);
                return false;
            }
            return true;
        }

        //Lista os números da sentença personalizada (op;num1;num2)
        public List<string> Numeros(string sentence, List<int> posicaoPV)
        {
            List<string> numeros = new List<string>();
            for(int i=0; i<posicaoPV.Count;i++)
            {
                try
                {
                    if (i == posicaoPV.Count-1)
                    {
                        int num = int.Parse(sentence.Substring(posicaoPV[i] + 1, sentence.Length-1 - posicaoPV[i]));
                        numeros.Add(num+"");
                    }
                    else
                    {
                        int num = int.Parse(sentence.Substring(posicaoPV[i] + 1, posicaoPV[i+1]- posicaoPV[i]-1));
                                                                       // 6                  8-4
                        numeros.Add(num+"");
                    }
                }
                catch(FormatException)
                {
                    numeros.Clear();
                }
            }
            return numeros;
        }

        //Método p/ verificar se a senteça passada é válida
        public bool ValidaSentenca(string sentence)
        {
            List<int> posicaoPV = PosicaoPV(sentence);
            string operacao = GetOperacao(sentence);
            bool ultimoElemValido = VerificaUltimoElem(sentence);
            if (posicaoPV.Count < 2)
                return false;
            if (operacao.Equals("error"))
                return false;
            if (!ultimoElemValido)
                return false;
            return true;
        }

        //Método p/ exibir os resultados na tela com fundo branco e fonte preta
        public void DestacaBackground(string resultado)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(resultado);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Método p/ exibir os erros na tela com fundo red e fonte branca
        public void ExibeErro(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", msg);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /* Método p/ ler e retornar dois numeros que serão utilizados nas operações
         * Como essa tarefa ocorre muitas vezes, resolvi criar esse método (DRY)*/
        public string[] Ler2Numeros()
        {
            string[] numeros = new string[2];
            Console.WriteLine("Digite o primeiro numero: ");
            numeros[0] = Console.ReadLine();
            Console.WriteLine("Digite o segundo numero: ");
            numeros[1] = Console.ReadLine();
            return numeros;
        }

        // Método p/ ler e retornar N numeros
        public List<string> LerNNumeros()
        {
            List<string> numeros = new List<string>();
            string num;
            Console.WriteLine("Insira os valores, teclando 'Enter' ao final de cada." +
                                  " Insira o '+' para finalizar:");
            do{
                num = Console.ReadLine();
                if(!num.Equals(""))
                    numeros.Add(num);
            } while (!numeros[numeros.Count - 1].Equals("+"));
            return numeros;
        }
        
        //Método que separa o Nome da Sentença a ser calculada
        public string[] GetNomeSentenca(string linhaDoArquivo)
        {
            List<int> pv = PosicaoPV(linhaDoArquivo);

            string[] nomeSentence = new string[2];//array para armazenar o nome e a senteça que o acompanha

            nomeSentence[0] = linhaDoArquivo.Substring(0, pv[0]);//o nome
            nomeSentence[1] = linhaDoArquivo.Substring(pv[0] + 1, linhaDoArquivo.Length-1 - pv[0]);//a sentença

            return nomeSentence;
        }

    }
}
