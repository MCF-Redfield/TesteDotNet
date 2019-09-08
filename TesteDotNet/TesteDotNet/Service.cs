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
                return false;
                throw;
            }
            return true;
        }

        public List<int> Numeros(string sentence, List<int> posicaoPV)
        {
            List<int> numeros = new List<int>();
            for(int i=0; i<posicaoPV.Count;i++)
            {
                try
                {
                    if (i == posicaoPV.Count-1)
                    {
                        //Console.WriteLine(sentence.Substring(posicaoPV[i] + 1, sentence.Length-1 - posicaoPV[i]));
                        int num = int.Parse(sentence.Substring(posicaoPV[i] + 1, sentence.Length-1 - posicaoPV[i]));
                        numeros.Add(num);
                    }
                    else
                    {
                        //Console.WriteLine(sentence.Substring(posicaoPV[i] + 1, posicaoPV[i+1]- posicaoPV[i]-1));
                        int num = int.Parse(sentence.Substring(posicaoPV[i] + 1, posicaoPV[i+1]- posicaoPV[i]-1));
                        numeros.Add(num);
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
            if (posicaoPV.Count<2)
                return false;
            if(operacao.Equals("error"))
                return false;
            if (!ultimoElemValido)
                return false;

            return true;
        }
    }
}
