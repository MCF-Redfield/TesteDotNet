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

        //Realiza soma de dois números
        public string Somar(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) + double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                return "FormatException";
            }
        }
        
        //Realiza soma de n números
        public string Somar(List<string> numeros)
        {
            double total = 0;
            for(int i=0; i<numeros.Count-1; i++)
            {
                try
                {
                    total+= double.Parse(numeros[i]);
                }
                catch (FormatException)
                {
                    return "FormatException";
                }
            }
            return total + "";
        }
        
        //Realiza subtração entre dois números
        public string Subtrair(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) - double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                return "FormatException";
            }
        }
        
        //Realiza divisão entre dois números
        public string Dividir(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) / double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                return "FormatException";
            }
        }

        //Realiza multiplicação de dois números
        public string Multiplicar(string num1, string num2)
        {
            try
            {
                double resultado = double.Parse(num1) * double.Parse(num2);
                return resultado + "";
            }
            catch (FormatException)
            {
                return "FormatException";
            }
        }

        //Realiza a operação de acordo com a senteça passada (op;num1;num2)
        public string SentecaPersonalizada(string sentence)
        {
            if (service.ValidaSentenca(sentence) == true)
            {
                List<int> posicaoPV = service.PosicaoPV(sentence);//posição do ';' dentro da sentença
                List<string> numerosSentence = service.Numeros(sentence, posicaoPV);// números da sentença
                string operacao = service.GetOperacao(sentence);//operação da sentença
                string resultado = "error";
                
                switch (operacao)
                {
                    case "soma":
                        if (numerosSentence.Count > 2)
                            resultado = Somar(numerosSentence);
                        else
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

        //Método que calcula a média de N números
        public string MediaNumeros(List<string> numeros)
        {
            double media;
            try
            {
                double divisor = numeros.Count-1;
                double total = double.Parse(Somar(numeros));
                media = total/divisor;
            }
            catch(FormatException)
            {
                return "FormatException";
            }
            return media+"";
        }

        //Realiza soma somente dos números pares
        public string SomarOnlyPares(List<string> numeros)
        {
            double total = 0;
            for (int i = 0; i < numeros.Count - 1; i++)
            {
                try
                {
                    if(double.Parse(numeros[i]) % 2==0)
                    total += double.Parse(numeros[i]);
                }
                catch (FormatException)
                {
                    return "FormatException";
                }
            }
            return total + "";
        }

        //Método que lê o arquivo, armazena no dicionário e imprime o resultado
        public void CriarDicionario()
        {
            string[] nomeOperacao = System.IO.File.ReadAllLines(@"E:\Estudos\Github\TesteDotNet\TesteDotNet\TesteDotNet\NomesOperacoes.txt");
            IDictionary<string, string> hashPessoas = new Dictionary<string, string>();
            for(int i=0; i<nomeOperacao.Length;i++)
            {
                if (!nomeOperacao[i].Equals(""))
                    hashPessoas.Add(""+service.GetNomeSentenca(nomeOperacao[i])[0],
                                    ""+SentecaPersonalizada(service.GetNomeSentenca(nomeOperacao[i])[1]));
            }
            foreach (var pair in hashPessoas)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }

        }
    }
        
}
