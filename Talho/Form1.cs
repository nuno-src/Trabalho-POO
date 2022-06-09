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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            //NÃO APAGAR CODIGO A BAIXO, CODIGO PARA LOGIN, SE DESCOMNETAR FICA A FUNCIONAR
            
            this.Enabled = false;
            this.Opacity = 0;
            this.Hide();

            FormLogIn fl = new FormLogIn(this);
            fl.Show();
            
            
        }




        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Data dataTemp = new Data(dateTimePicker1.Value.Day,
                dateTimePicker1.Value.Month, dateTimePicker1.Value.Year);

            Produto ptemp = new Produto(textBoxNome.Text, int.Parse(numericUpDownQuant.Value.ToString()),
                 double.Parse(textBoxPreco.Text), textBoxDescr.Text, dataTemp);

            listBox1.Items.Add(ptemp);
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Create("dadosproduto.txt");
            //AesCryptoServiceProvider cod = new AesCryptoServiceProvider();

            Aes cod = Aes.Create();
            CryptoStream cr = new CryptoStream(fs, cod.CreateEncryptor(), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cr);

            foreach (Produto p in listBox1.Items)
            {
                sw.WriteLine(p.EnviarFicheiro());
            }

            sw.Close();
            fs.Close();

            FileStream fsChave = File.Create("chave.key");

            BinaryWriter bw = new BinaryWriter(fsChave);

            bw.Write(cod.Key);
            bw.Write(cod.IV);
            bw.Close();
            fsChave.Close();

            MessageBox.Show("Dados Guardados.");
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
