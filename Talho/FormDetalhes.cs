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
            Produto pTemp = new Produto();

            if (fPrincipal != null)
            {
                pTemp = fPrincipal.listBox1.SelectedItem as Produto;
            }
           

            labelNome.Text = pTemp.GetNome();
            labelQuantidade.Text = pTemp.GetQuantidade().ToString();
            labelDescricao.Text = pTemp.GetDescricao();
            labelPreco.Text = pTemp.GetPreco().ToString() + " €";
            labelValidade.Text = pTemp.GetValidade().ToString();

            progressBar1.Value = pTemp.GetQuantidade();
        }
    }
}
