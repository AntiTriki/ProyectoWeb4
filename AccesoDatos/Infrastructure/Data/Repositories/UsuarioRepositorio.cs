using System;
using System.Collections.Generic;
using System.Linq;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.DataModels;

namespace AccesoDatos.Infrastructure.Data.Repositories
{
    public class UsuarioRepositorio : EFRepositorio<Usuario>
    {
        public int GuardarUsuario(string usuario, string nombre, string correo, string clave, DateTime fechaNac, int sexo, int idPais)
        {
            Usuario usr = new Usuario()
            {
                USUARIO1 = usuario,
                Nombre = nombre,
                Correo = correo,
                Clave = clave == "" ? null : clave,
                FechaNacimiento = fechaNac,
                SEXO = (short?)sexo,
                IdPais = idPais
            };
            Add(usr);
            SaveChanges();
            return usr.IdUsuario;
        }
        public void ModificarUsuario(int idUsuario, string usuario, string nombre, string correo, DateTime fechaNac, int sexo, int idPais)
        {
            Usuario usr = this.Get(idUsuario);
            usr.USUARIO1 = usuario;
            usr.Nombre = nombre;
            usr.Correo = correo;
            usr.FechaNacimiento = fechaNac;
            usr.SEXO = (short?)sexo;
            usr.IdPais = idPais;
            Update(usr);
            SaveChanges();
        }

        public void EliminarUsuario(int idUsuario)
        {
            Usuario usr = this.Get(idUsuario);
            Remove(usr);
            SaveChanges();
        }

        public Usuario ObtenerUsuario(int idUsuario)
        {
            return Get(idUsuario);
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            return GetAll().Select(x => new UsuarioDTO()
            {
                IdUsuario = x.IdUsuario,
                Usuario = x.USUARIO1,
                Nombre = x.Nombre,
                Correo = x.Correo,
                FechaNac = x.FechaNacimiento.Value,
                Clave = x.Clave,
                IdSexo = x.SEXO.Value,
                Sexo = x.SEXO.Value == 1 ? "Masculino" : "Femenino",
                IdPais = x.IdPais
            }).ToList();
        }

    }
}
