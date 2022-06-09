using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Talho
{
    //Form1 fgestor;

    public partial class FormCliente : Form
    {

        public FormCliente()
        {
            InitializeComponent();

            //fg = fp;
        }


        private void FormCliente_Load(object sender, EventArgs e)
        {
            //foreach (Produto p in fPrincipal.listBox1.Items)
            //{

            //    listBox1.Items.Add(p);
            //}
            if (File.Exists("dadosproduto.txt"))
            {
                FileStream fich = File.OpenRead("dadosproduto.txt");
                FileStream chave = File.OpenRead("chave.key");

                //AesCryptoServiceProvider cod = new AesCryptoServiceProvider();
                Aes cod = Aes.Create();
                BinaryReader brKey = new BinaryReader(chave);
                cod.Key = brKey.ReadBytes(32);
                cod.IV = brKey.ReadBytes(16);

                CryptoStream cs = new CryptoStream(fich, cod.CreateDecryptor(), CryptoStreamMode.Read);

                StreamReader sr = new StreamReader(cs);

                string linha = sr.ReadLine();

                while (linha != null)
                {
                    string[] auxP = linha.Split('|');
                    string[] auxD = auxP[4].Split('/');

                    Data d = new Data(int.Parse(auxD[0]), int.Parse(auxD[1]), int.Parse(auxD[2]));

                    Produto p = new Produto(auxP[0], int.Parse(auxP[1]), double.Parse(auxP[2]), auxP[3], d);

                    listBox1.Items.Add(p);

                    linha = sr.ReadLine();
                }
                sr.Close();
                fich.Close();
                chave.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void FormCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
