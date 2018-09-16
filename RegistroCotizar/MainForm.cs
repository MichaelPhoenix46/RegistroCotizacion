using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroCotizar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void registroDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.RArticulos r = new UI.Registros.RArticulos();
            r.Show();
        }

        private void registroDeConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Consultas.CArticulo c = new UI.Consultas.CArticulo();
            c.Show();
        }
    }
}
