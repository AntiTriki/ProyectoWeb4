using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Domain.Entities
{
    public class Empresa
    {
        public int id;
        public string correo;
        public string nombre;       
        public string contra;               
        public string imagen;
        public string descripcion;
        public int? id_categoria;
        public string direccion;
        public string telefono;
        public int valido;
    }
    public class EmpresaAbmDTO
    {
        public List<Empresa> Empresas;
        public List<Categoria> Categorias;
    }
}
