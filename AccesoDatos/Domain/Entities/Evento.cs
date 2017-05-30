using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Domain.Entities
{
    public class Evento
    {
        public int id;
        public string fecha_inicio_evento;
        public string fecha_final_evento;
        public string fecha_inicio_publicacion;
        public string fecha_final_publicacion;
        public int id_categoria_evento;
        public string nombre;
        public int id_empresa;
        public string imagen;
        public string descripcion;
        public int id_ubicacion;
        public int stock;
        public int stock_inicial;
        public int valido;
    }
}

