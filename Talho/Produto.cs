using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talho
{
    internal class Produto
    {
        //Atributos
        private string nome;
        private int quantidade;
        private double preco;
        private Data validade;
        private string descricao;
        //Construtor
        public Produto()
        {
            nome = "";
            quantidade = 0;
            preco = 0;
            descricao = "";
            validade = new Data();

        }
        public Produto(string nNome, int nQuantidade, double nPreco, string nDescricao, Data nValidade)
        {
            nome = nNome;
            quantidade = nQuantidade;
            preco = nPreco;
            descricao = nDescricao;
            validade = nValidade;

        }

        //Métodos
        public string GetNome()
        {
            return nome;
        }
        public void SetNome(string nNome)
        {
            nome = nNome;
        }
        public int GetQuantidade()
        {
            return quantidade;
        }
        public void SetQuantidade(int nQuantidade)
        {
            quantidade = nQuantidade;
        }
        public string GetDescricao()
        {
            return descricao;
        }
        public void SetDescricao(string nDescricao)
        {
            descricao = nDescricao;
        }
        public double GetPreco()
        {
            return preco;
        }
        public void SetPreco(double nPreco)
        {
            preco = nPreco;
        }
        public Data GetValidade()
        {
            return validade;
        }
        public void SetValidade(Data nValidade)
        {
            validade = nValidade;
        }

        public string EnviarFicheiro()
        {
            return nome + "|" + quantidade + "|" + preco + "|" + descricao + "|" + validade;
        }

        public override string ToString()
        {
            return nome + " - " + "Qt:" + quantidade + " - " + preco + "€";
        }

    }

}
