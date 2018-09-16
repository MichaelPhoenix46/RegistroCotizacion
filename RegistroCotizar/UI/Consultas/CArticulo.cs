using RegistroCotizar.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroCotizar.UI.Consultas
{
    public partial class CArticulo : Form
    {
        public CArticulo()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.Articuloid == id;
                   
                    break;
                case 1:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text);
                    
                    break;
                case 2:// Cantidad
                    filtro = x => x.CantidadCotizada.Equals(CriteriotextBox.Text);
                   
                    break;
                case 3:// Existencia
                    filtro = x => x.Existencia.Equals(CriteriotextBox.Text);
                   
                    break;
                case 4:// Precio
                    filtro = x => x.Precio.Equals(CriteriotextBox.Text);

                    break;
                case 5:// Precio
                    filtro = x => x.FechaVencimiento.Equals(CriteriotextBox.Text);

                    break;
            }
            ConsultadataGridView.DataSource = ArticuloBLL.GetList(filtro);

        }


    }
}
