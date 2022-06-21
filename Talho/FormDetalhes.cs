using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talho
{
    public partial class FormDetalhes : Form
    {
        Form1 fPrincipal;
        
        public FormDetalhes(Form1 fp)
        {
            InitializeComponent();
            fPrincipal = fp;
        }

        private void FormDetalhes_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
            Produto pTemp = new Produto();

            if (fPrincipal != null)
            {
                pTemp = fPrincipal.listBox1.SelectedItem as Produto;
            }

            pictureBox1.ImageLocation = pTemp.GetImagem();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            labelNome.Text = pTemp.GetNome();
            labelQuantidade.Text = pTemp.GetQuantidade().ToString();
            labelDescricao.Text = pTemp.GetDescricao();
            labelPreco.Text = pTemp.GetPreco().ToString() + " €";
            labelValidade.Text = pTemp.GetValidade().ToString();

            progressBar1.Value = pTemp.GetQuantidade();
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void labelPreco_Click(object sender, EventArgs e)
        {

        }

        private void labelDescricao_Click(object sender, EventArgs e)
        {

        }
    }
}
