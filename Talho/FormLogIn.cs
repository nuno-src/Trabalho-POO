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
    public partial class FormLogIn : Form
    {
        Form1 fgestor;
        FormCliente fcliente;
        public FormLogIn(Form1 nform1)
        {
            InitializeComponent();
            fgestor = nform1;
        }
        public FormLogIn(FormCliente nformcliente)
        {
            InitializeComponent();
            fcliente = nformcliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButtonGestor.Checked == true)
            {
                if(textBoxNome.Text == "gestor")
                {
                    this.Close();

                    fgestor.Enabled = true;
                    fgestor.Opacity = 100;
                    fgestor.Activate();
                }
                else
                {
                    MessageBox.Show("Erro Login!");
                }
            }
            else if(radioButtonCliente.Checked == true)
            {
                if (textBoxNome.Text == "cliente")
                {
                    this.Close();

                    FormCliente fl = new FormCliente();
                    
                    fl.Show();
                }
                else
                {
                    MessageBox.Show("Erro Login!");
                }
            }
            else
            {
                MessageBox.Show("Necessario Selecionar Gestor / Cliente");
            }
        }

        //private void FormLogIn_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Environment.Exit(1);
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
