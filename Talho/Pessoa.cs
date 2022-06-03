using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talho
{
    internal class Pessoa
    {
        protected string nome;
        protected string email;
        protected Data dataNasc;

        public Pessoa()
        {
            nome = "";
            email = "";
            dataNasc = new Data();
        }
        public Pessoa(string nNome, string nEmail, Data nDataNAsc)
        {
            nome = nNome;
            email = nEmail;
            dataNasc = nDataNAsc;
        }
        public Pessoa(string nNome, string nEmail, int nDia, int nMes, int nAno)
        {
            nome = nNome;
            email = nEmail;
            dataNasc = new Data(nDia, nMes, nAno);
        }
        public string GetNome()
        {
            return nome;
        }
        public void SetNome(string nNome)
        {
            nome = nNome;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string nEmail)
        {
            email = nEmail;
        }
        public Data GetDataNasc()
        {
            return dataNasc;
        }
        public void SetDataNasc(Data nDataNasc)
        {
            dataNasc = nDataNasc;
        }
        public void SetDataNasc(int nDia, int nMes, int nAno)
        {
            dataNasc.SetDia(nDia);
            dataNasc.SetMes(nMes);
            dataNasc.SetAno(nAno);
        }

        public override string ToString()
        {
            return nome + " - " + dataNasc;
        }
    }

}
