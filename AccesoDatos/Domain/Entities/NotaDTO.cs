using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Domain.Entities
{
    public class NotaDTO
    {
        public int NroNota;
        public string Nombre;
        public string Fecha;
        public List<DetalleVentaDTO> Detalle;
    }

    public class DetalleVentaDTO
    {
        public int idArticulo;
        public int Cantidad;
        public double Precio;
    }
}
