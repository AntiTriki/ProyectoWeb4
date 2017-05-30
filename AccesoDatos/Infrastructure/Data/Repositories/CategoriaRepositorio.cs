using System.Collections.Generic;
using System.Linq;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.DataModels;
namespace AccesoDatos.Infrastructure.Data.Repositories
{
    public class CategoriaRepositorio : EFRepositorio<categoria_empresa>
    {
        

        public categoria_empresa ObtenerCategoria(int id)
        {
            return Get(id);
        }

        public List<Categoria> ObtenerCategorias()
        {
            return GetAll().Select(x => new Categoria()
            {
                id = x.id,
                nombre = x.nombre,
                id_subcategoria = x.id_subcategoria
            }).ToList();
        }

    }
}
