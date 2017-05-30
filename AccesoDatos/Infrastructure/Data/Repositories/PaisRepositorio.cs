using System.Collections.Generic;
using System.Linq;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.DataModels;

namespace AccesoDatos.Infrastructure.Data.Repositories
{
    public class PaisRepositorio : EFRepositorio<Pai>
    {
        public int GuardarPais(string nombre, string descripcion)
        {
            Pai pais = new Pai()
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            Add(pais);
            SaveChanges();
            return pais.IdPais;
        }
        public void ModificarPais(int idPais, string nombre, string descripcion)
        {
            Pai pais = this.Get(idPais);
            pais.Nombre = nombre;
            pais.Descripcion = descripcion;
            Update(pais);
            SaveChanges();
        }

        public void EliminarPais(int idPais)
        {
            Pai pais = this.Get(idPais);
            Remove(pais);
            SaveChanges();
        }

        public Pai ObtenerPais(int idPais)
        {
            return Get(idPais);
        }

        public List<PaisDTO> ObtenerPaises()
        {
            return GetAll().Select(x => new PaisDTO()
            {
                IdPais = x.IdPais,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            }).ToList();
        }

    }
}
