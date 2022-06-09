using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talho
{
    internal class Gestor : Pessoa
    {
        private int numEmpregado;
        public Gestor()
        {
            numEmpregado = 0;
        }

        public Gestor(string nNome, string nEmail, Data nDataNAsc, int nnumEmpregado)
        {
            nome = nNome;
            email = nEmail;
            dataNasc = nDataNAsc;
            numEmpregado = nnumEmpregado;
        }
        public int GetNumEmpreg()
        {
            return numEmpregado;
        }
        public void SetGrau(int nnumEmpregado)
        {
            numEmpregado = nnumEmpregado;
        }
    }
}
