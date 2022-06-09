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
    //Form1 fgestor;
    public partial class FormCliente : Form
    {

        public FormCliente()
        {
            InitializeComponent();

            //fPrincipal = fp;
        }


        private void FormCliente_Load(object sender, EventArgs e)
        {
            //foreach (Produto p in fPrincipal.listBox1.Items)
            //{
                
            //    listBox1.Items.Add(p);
            //}
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
