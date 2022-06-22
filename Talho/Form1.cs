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
            this.Icon = Properties.Resources.Icon;
            buttonEditar.Enabled = false;

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
                 double.Parse(textBoxPreco.Text), textBoxPathImg.Text, textBoxDescr.Text, dataTemp);

            listBox1.Items.Add(ptemp);
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            listBox1.SelectedItem = null;
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

        

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {


                Produto pTemp = listBox1.SelectedItem as Produto;

                Data dataTemp = new Data(dateTimePicker1.Value.Day,
                dateTimePicker1.Value.Month, dateTimePicker1.Value.Year);


                pTemp.SetNome(textBoxNome.Text);
                pTemp.SetQuantidade(int.Parse(numericUpDownQuant.Text));
                pTemp.SetPreco(double.Parse(textBoxPreco.Text));
                pTemp.SetImagem(textBoxPathImg.Text);
                pTemp.SetValidade(dataTemp);
                pTemp.SetDescricao(textBoxDescr.Text);


                //if(textBoxNome.Text != string.Empty)
                //{
                //    pTemp.SetNome(textBoxNome.Text);
                //}

                //if (numericUpDownQuant.Text != null)
                //{
                //    pTemp.SetQuantidade(int.Parse(numericUpDownQuant.Text));
                //}

                //if (textBoxPreco.Text != string.Empty)
                //{
                //    pTemp.SetPreco(double.Parse(textBoxPreco.Text));
                //}

                //if (dateTimePicker1 != null)
                //{
                //    pTemp.SetValidade(dataTemp);
                //}

                //if (textBoxDescr.Text != string.Empty)
                //{
                //    pTemp.SetDescricao(textBoxDescr.Text);
                //}


                //listBox1.Refresh();

                //listBox1.Items.Insert(listBox1.SelectedIndex, pTemp);

                MessageBox.Show("Produto editado com sucesso!");
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                FormDetalhes fVer = new FormDetalhes(this);
                fVer.Show();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                buttonEditar.Enabled = true;

                Produto pTemp = listBox1.SelectedItem as Produto;

                //Data dataTemp = new Data(dateTimePicker1.Value.Day,
                //dateTimePicker1.Value.Month, dateTimePicker1.Value.Year);

                textBoxNome.Text = pTemp.GetNome();
                numericUpDownQuant.Text = pTemp.GetQuantidade().ToString();
                textBoxPreco.Text = pTemp.GetPreco().ToString();
                textBoxPathImg.Text = pTemp.GetImagem();
                //dateTimePicker1.Value.Day = pTemp.GetValidade().GetDia();
                //dateTimePicker1. = pTemp.GetValidade().GetMes();
                //dateTimePicker1.Value.Year = pTemp.GetValidade().GetAno();
                textBoxDescr.Text = pTemp.GetDescricao();


            }
            
        }

        private void buttonBrowseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxPathImg.Text = ofd.FileName;
            }
            File.Copy(ofd.FileName, ofd.SafeFileName);
            textBoxPathImg.Text = ofd.SafeFileName;
        }





        private void maisCaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produto minpreco = listBox1.Items[0] as Produto;
            Produto maxpreco = listBox1.Items[0] as Produto;

            foreach (Produto x in listBox1.Items)
            {
                if (x.GetPreco() < minpreco.GetPreco())
                {
                    minpreco = x;
                }
                else if (x.GetPreco() == minpreco.GetPreco())
                {
                    if (x.GetPreco() < minpreco.GetPreco())
                    {
                        minpreco = x;
                    }
                    else if (x.GetPreco() == minpreco.GetPreco())
                    {
                        if (x.GetPreco() < minpreco.GetPreco())
                        {
                            minpreco = x;
                        }
                    }
                }
            }

            foreach (Produto x in listBox1.Items)
            {
                if (x.GetPreco() > maxpreco.GetPreco())
                {
                    maxpreco = x;
                }
            }
            MessageBox.Show(minpreco.GetNome() + " | Qt: " + minpreco.GetQuantidade() + " | " +
            minpreco.GetPreco() + "€", "Produto Preço MIN");

            MessageBox.Show(maxpreco.GetNome() + " | Qt: " + maxpreco.GetQuantidade() + " | " +
            minpreco.GetPreco() + "€", "Produto Preço MAX");
        }

        private void maisBaratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produto minVal = listBox1.Items[0] as Produto;

            foreach (Produto x in listBox1.Items)
            {
                if (x.GetValidade().GetAno() < minVal.GetValidade().GetAno())
                {
                    minVal = x;
                }
                else if (x.GetValidade().GetAno() == minVal.GetValidade().GetAno())
                {
                    if (x.GetValidade().GetMes() < minVal.GetValidade().GetMes())
                    {
                        minVal = x;
                    }
                    else if (x.GetValidade().GetMes() == minVal.GetValidade().GetMes())
                    {
                        if (x.GetValidade().GetDia() < minVal.GetValidade().GetDia())
                        {
                            minVal = x;
                        }
                    }
                }
            }

            MessageBox.Show(minVal.GetNome() + " | Qt: " + minVal.GetQuantidade() + " | " +
            minVal.GetPreco() + "€", "Produto Validade Menor");
        }

        private void foraDeValidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data dataHoje = new Data(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);


            Produto foraVal = listBox1.Items[0] as Produto;
            foreach (Produto x in listBox1.Items)
            {
                if (x.GetValidade() < dataHoje)
                {
                    foraVal = x;
                    MessageBox.Show(foraVal.GetNome() + " | Qt: " + foraVal.GetQuantidade() + " | " +
                    foraVal.GetPreco() + "€", "Produto fora da validade");
                }
            }
               
            

        }
    }
}
