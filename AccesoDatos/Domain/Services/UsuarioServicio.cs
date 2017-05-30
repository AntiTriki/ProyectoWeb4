using System;
using System.Collections.Generic;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.Repositories;

namespace AccesoDatos.Domain.Services
{
    public class UsuarioServicio
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly PaisRepositorio _paisRepositorio;

        public UsuarioServicio()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
            _paisRepositorio = new PaisRepositorio();
        }

        public int GuardarUsuario(int idUsuario, string usuario, string nombre, string correo, string clave, DateTime fechaNac, int sexo, int idPais)
        {
            if (idUsuario == 0)
                idUsuario = _usuarioRepositorio.GuardarUsuario(usuario, nombre, correo, clave, fechaNac, sexo, idPais);
            else
                _usuarioRepositorio.ModificarUsuario(idUsuario, usuario, nombre, correo, fechaNac, sexo, idPais);

            return idUsuario;
        }

        public void EliminarPais(int idUsuario)
        {
            _usuarioRepositorio.EliminarUsuario(idUsuario);
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            return _usuarioRepositorio.ObtenerUsuarios();
        }

        public UsuarioAbmDTO ObtenerUsuariosAbm()
        {
            return new UsuarioAbmDTO()
            {
                Usuarios = _usuarioRepositorio.ObtenerUsuarios(),
                Paises = _paisRepositorio.ObtenerPaises()
            };
                
        }

    }
}
