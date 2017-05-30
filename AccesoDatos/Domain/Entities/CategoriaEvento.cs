using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Domain.Entities
{
    public class CategoriaEvento
    {
        public int id;
        public string nombre;
        public int? id_subcategoria;
    }
}
