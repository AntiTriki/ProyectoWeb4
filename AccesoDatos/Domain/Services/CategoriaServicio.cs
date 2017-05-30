using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.Repositories;

namespace AccesoDatos.Domain.Services
{
    public class CategoriaServicio
    {
        private readonly CategoriaRepositorio _catRepositorio;

        public CategoriaServicio()
        {
            _catRepositorio = new CategoriaRepositorio();
        }

        

        

        public List<Categoria> ObtenerCategorias()
        {
            return _catRepositorio.ObtenerCategorias();
        }
    }
}
