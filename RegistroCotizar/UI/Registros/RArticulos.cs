using RegistroCotizar.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RegistroCotizar.UI.Registros
{
    public partial class RArticulos : Form
    {
        public RArticulos()
        {
            InitializeComponent();
        }

        private Articulos LLenaClase()
        {
            Articulos articulos = new Articulos();
            articulos.Articuloid = Convert.ToInt32(IdnumericUpDown.Value);
            articulos.FechaVencimiento = FechaVencimientodateTimePicker.Value;
            articulos.Precio = PrecionumericUpDown.Value;
            articulos.Existencia = ExistencianumericUpDown.Value;
            articulos.CantidadCotizada = CantidadnumericUpDown.Value;

            return articulos;
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                ArticuloerrorProvider.SetError(DescripciontextBox, "llenar el campo de descripcion");
                return false;
            }
            if (PrecionumericUpDown.Value == 0)
            {
                ArticuloerrorProvider.SetError(PrecionumericUpDown, "El precio no debe ser 0");
                return false;
            }
            if (ExistencianumericUpDown.Value == 0)
            {
                ArticuloerrorProvider.SetError(ExistencianumericUpDown, "La existencia no debe ser 0");
                return false;
            }
            if (FechaVencimientodateTimePicker.Value <= DateTime.Today)
            {
                ArticuloerrorProvider.SetError(FechaVencimientodateTimePicker, "La fecha de vencimiento no debe ser hoy ni dias antes");
            }

            if (CantidadnumericUpDown.Value == 0)
            {
                ArticuloerrorProvider.SetError(CantidadnumericUpDown, "La cantidad no debe ser 0");
                return false;
            }

            return true;
        }


        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Articulos articulos = ArticuloBLL.Buscar(id);

            if (articulos != null)
            {
                PrecionumericUpDown.Value = articulos.Precio;
                DescripciontextBox.Text = articulos.Descripcion;
                ExistencianumericUpDown.Value = articulos.Existencia;
                CantidadnumericUpDown.Value = articulos.CantidadCotizada;
                FechaVencimientodateTimePicker.Value = articulos.FechaVencimiento;
            }
            else
            {
                MessageBox.Show("no se encontro", "buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
            {
                MessageBox.Show("llenar el campo vacio", "trate de guardar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Articulos articulos = LLenaClase();
                bool paso = false;

                if (IdnumericUpDown.Value == 0)
                {
                    paso = ArticuloBLL.Guardar(articulos);
                }
                else
                {
                    paso = ArticuloBLL.Modificar(articulos);
                }

                if (paso)
                {
                    MessageBox.Show("Se ha guardado", "aceptado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha modificado", "error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechaVencimientodateTimePicker.Value = DateTime.Now;
            DescripciontextBox.Clear();
            PrecionumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;
            ExistencianumericUpDown.Value = 0;

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            if (ArticuloBLL.Eliminar(id))

            {
                MessageBox.Show("eliminado", "exitosamente",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                IdnumericUpDown.Value = 0;
                FechaVencimientodateTimePicker.Value = DateTime.Now;
                DescripciontextBox.Clear();
                PrecionumericUpDown.Value = 0;
                CantidadnumericUpDown.Value = 0;
                ExistencianumericUpDown.Value = 0;
            }
            else
            {
                MessageBox.Show("no fue eliminado", "trate de nuevo",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ArticuloerrorProvider.Clear();
        }
    

    private void RArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
