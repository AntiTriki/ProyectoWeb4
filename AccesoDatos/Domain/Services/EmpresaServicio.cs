using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.Repositories;

namespace AccesoDatos.Domain.Services
{
    public class EmpresaServicio
    {
        private readonly EmpresaRepositorio _empresaRepositorio;
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public EmpresaServicio()
        {
            _empresaRepositorio = new EmpresaRepositorio();
            _categoriaRepositorio = new CategoriaRepositorio();
        }
        public int GuardarEmpresa(int id, string correo, string nombre, string contra, string imagen, string descripcion, string direccion, string telefono, int valido, int id_categoria)
        {
            if (id == 0)
                id = _empresaRepositorio.GuardarEmpresa(correo, nombre, contra, imagen, descripcion, direccion, telefono,valido, id_categoria);
            else
                _empresaRepositorio.ModificarEmpresa(id,correo, nombre, contra, imagen, descripcion, direccion, telefono, id_categoria);

            return id;
        }

        public void EliminarCategoria(int id)
        {
            _empresaRepositorio.EliminarEmpresa(id);
        }

        public List<Empresa> ObtenerEmpresas()
        {
            return _empresaRepositorio.ObtenerEmpresas();
        }

        public EmpresaAbmDTO ObtenerEmpresasAbm()
        {
            return new EmpresaAbmDTO()
            {
                Empresas = _empresaRepositorio.ObtenerEmpresas(),
                Categorias = _categoriaRepositorio.ObtenerCategorias()
            };

        }

    }
}
