using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegistroCotizar.Entidades
{
    public class Articulos
    {
        [Key]
        public int Articuloid { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Existencia{ get; set; }
        public Decimal CantidadCotizada { get; set; }

        public Articulos()
        {
            Articuloid = 0;
            FechaVencimiento = DateTime.Now;
            Descripcion = string.Empty;
            Precio = 0;
            Existencia = 0;
            CantidadCotizada = 0;

        }

    }
}
