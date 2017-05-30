using System;
using System.Collections.Generic;
using System.Linq;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Infrastructure.Data.DataModels;

namespace AccesoDatos.Infrastructure.Data.Repositories
{
    public class EmpresaRepositorio : EFRepository<empresa>
    {
        public int GuardarEmpresa(string correo, string nombre, string contra, string imagen, string descripcion, string direccion, string telefono, int valido, int id_categoria)
        {
            empresa e = new empresa()
            {
                correo= correo,
                nombre=nombre,
                contra=contra,
                imagen=imagen,
                descripcion= descripcion,
                direccion=direccion,
                telefono=telefono,
                valido=valido,
                id_categoria=id_categoria
            };
            Add(e);
            SaveChanges();
            return e.id;
        }
        public void ModificarEmpresa(int id, string correo, string nombre, string contra, string imagen, string descripcion, string direccion, string telefono,  int id_categoria)
        {
            empresa e = this.Get(id);

            e.correo = correo;
            e.nombre = nombre;
            e.imagen = imagen;
            e.contra = contra;
            e.descripcion = descripcion;
            e.direccion = direccion;
            e.telefono = telefono;
            e.id_categoria = id_categoria;
            Update(e);
            SaveChanges();
        }

        public void EliminarEmpresa(int id)
        {
            empresa e = this.Get(id);
            e.valido = 0;
            Update(e);
            SaveChanges();
        }

        public empresa ObtenerEmpresa(int id)
        {
            return Get(id);
        }

        public List<Empresa> ObtenerEmpresas()
        {
            return GetAll().Select(x => new Empresa()
            {
                id = x.id,
                correo = x.correo,
                nombre = x.nombre,
                imagen = x.imagen,
                descripcion = x.descripcion,
                direccion = x.direccion,
                telefono = x.telefono,
                
                id_categoria = x.id_categoria
            }).ToList();
        }

    }
}
