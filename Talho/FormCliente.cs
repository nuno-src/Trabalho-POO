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
        double total = 0;
        public FormCliente()
        {
            InitializeComponent();
            listBox1.AllowDrop = true;
            listBox2.AllowDrop = true;

            //fg = fp;
        }


        private void FormCliente_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;

            //label7.Visible = false;
            //textBox1.Visible = false;

            comboBox1.SelectedIndex = 0;
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
                    string[] auxD = auxP[5].Split('/');

                    Data d = new Data(int.Parse(auxD[0]), int.Parse(auxD[1]), int.Parse(auxD[2]));

                    Produto p = new Produto(auxP[0], int.Parse(auxP[1]), double.Parse(auxP[2]), auxP[3], auxP[4], d);

                    listBox1.Items.Add(p);

                    linha = sr.ReadLine();
                }
                sr.Close();
                fich.Close();
                chave.Close();
            }
        }
        

        private void FormCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.DoDragDrop(listBox1.SelectedItem.ToString(), DragDropEffects.Copy);
            }
            else
            {

            }
            
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            Produto pTemp = listBox1.SelectedItem as Produto;

            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);

            total = total + pTemp.GetPreco();
            labelTOTAL.Text = total.ToString() + "€";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //listBox2.Items.Add(listBox1.SelectedItem);
                //listBox1.Items.Remove(listBox1.SelectedItem);

                Produto pTemp = listBox1.SelectedItem as Produto;

                pTemp.SetQuantidade(1);

                //Produto ptemp = new Produto(listBox1.SelectedItem);

                listBox2.Items.Add(pTemp);

                total = total + pTemp.GetPreco();
                labelTOTAL.Text = total.ToString() + "€";
            }
            else
            {
                MessageBox.Show("Selecione o Produto Para Adicionar!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Produto pTemp = listBox2.SelectedItem as Produto;

                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);

                total = total - pTemp.GetPreco();
                labelTOTAL.Text = total.ToString() + "€";
            }
            else
            {
                MessageBox.Show("Selecione O Produto Para Remover!");
            }
        }


        private void button3_Click(object sender, EventArgs e)
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

            MessageBox.Show("Compra concluida.");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                label7.Visible = false;
                textBox1.Visible = false;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                label7.Visible = true;
                textBox1.Visible = true;
                label7.Text = "nº de telefone:";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label7.Visible = true;
                textBox1.Visible = false;
                label7.Text = "Insira o cartão.";
            }
            
        }
   
    }
}
