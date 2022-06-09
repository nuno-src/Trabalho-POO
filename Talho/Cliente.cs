using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talho
{
    
    internal class Cliente : Pessoa
    {
        private int nif;
        public Cliente()
        {
            nif = 0;
        }

        public Cliente(string nNome, string nEmail, Data nDataNAsc, int nNif)
        {
           
            nome = nNome;
            email = nEmail;
            dataNasc = nDataNAsc;
            nif = nNif;
            
        }
        public int GetNif()
        {
            return nif;
        }
        public void SetNif(int nNif)
        {
            nif = nNif;
        }




    }
}
