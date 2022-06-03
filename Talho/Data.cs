﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talho
{
    internal class Data
    {
        private int dia;
        private int mes;
        private int ano;
        public Data()
        {
            dia = 0;
            mes = 0;
            ano = 0;
        }
        public Data(int nDia, int nMes, int nAno)
        {
            dia = nDia;
            mes = nMes;
            ano = nAno;
        }
        public int GetDia()
        {
            return dia;
        }
        public void SetDia(int nDia)
        {
            dia = nDia;
        }
        public int GetMes()
        {
            return mes;
        }
        public void SetMes(int nMes)
        {
            mes = nMes;
        }

        public int GetAno()
        {
            return ano;
        }
        public void SetAno(int nAno)
        {
            ano = nAno;
        }

        public override string ToString()
        {
            return dia + "/" + mes + "/" + ano;
        }

        public static bool operator > (Data a, Data b)
        {
            if (a.ano > b.ano)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes > b.mes)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes == b.mes && a.dia > b.dia)
            {
                return true;
            }
            return false;
        }
        public static bool operator < (Data a, Data b)
        {
            if (a.ano < b.ano)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes < b.mes)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes == b.mes && a.dia < b.dia)
            {
                return true;
            }
            return false;
        }

        public static bool operator >= (Data a, Data b)
        {
            if (a.ano > b.ano)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes > b.mes)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes == b.mes && a.dia >= b.dia)
            {
                return true;
            }
            return false;
        }

        public static bool operator <= (Data a, Data b)
        {
            if (a.ano < b.ano)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes < b.mes)
            {
                return true;
            }
            else if (a.ano == b.ano && a.mes == b.mes && a.dia <= b.dia)
            {
                return true;
            }
            return false;
        }

        public static bool operator == (Data a, Data b)
        {
            if (a.ano == b.ano && a.mes == b.mes && a.dia == b.dia)
            {
                return true;
            }
            return false;
        }
        public static bool operator != (Data a, Data b)
        {
            return !(a == b);
        }
    }

}
