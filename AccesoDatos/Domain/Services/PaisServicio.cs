using System.Collections.Generic;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.Repositories;

namespace AccesoDatos.Domain.Services
{
    public class PaisServicio
    {
        private readonly PaisRepositorio _paisRepositorio;

        public PaisServicio()
        {
            _paisRepositorio = new PaisRepositorio();
        }

        public int GuardarPais(string nombre, string descripcion, int idPais = 0)
        {
            if (idPais == 0)
                idPais = _paisRepositorio.GuardarPais(nombre, descripcion);
            else
                _paisRepositorio.ModificarPais(idPais, nombre, descripcion);

            return idPais;
        }

        public void EliminarPais(int idPais)
        {
            _paisRepositorio.EliminarPais(idPais);
        }

        public List<PaisDTO> ObtenerPaises()
        {
            return _paisRepositorio.ObtenerPaises();
        }
        
    }
}
