﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlantillaComercio.Views
{
    using AccesoDatos.Infrastructure.Data.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class p1Entities : DbContext
    {
        public p1Entities()
            : base("name=p1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria_empresa> categoria_empresa { get; set; }
        public virtual DbSet<categoria_evento> categoria_evento { get; set; }
        public virtual DbSet<empresa> empresa { get; set; }
        public virtual DbSet<evento_empresa> evento_empresa { get; set; }
        public virtual DbSet<pago_usuario> pago_usuario { get; set; }
        public virtual DbSet<publicidad> publicidad { get; set; }
        public virtual DbSet<tipoentrada> tipoentrada { get; set; }
        public virtual DbSet<transaccion_previa> transaccion_previa { get; set; }
        public virtual DbSet<ubicacion_evento> ubicacion_evento { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
