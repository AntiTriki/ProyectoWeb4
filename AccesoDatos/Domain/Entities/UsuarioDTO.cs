using System;
using System.Collections.Generic;

namespace AccesoDatos.Domain.Entities
{
    public class UsuarioDTO
    {
        public int IdUsuario;
        public string Usuario;
        public string Nombre;
        public string Correo;
        public string Clave;
        public DateTime FechaNac;
        public int IdSexo;
        public string Sexo;
        public int IdPais;
    }
    public class UsuarioAbmDTO
    {
        public List<UsuarioDTO> Usuarios;
        public List<PaisDTO> Paises;
    }
}
