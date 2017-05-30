//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos.Infrastructure.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa()
        {
            this.evento_empresa = new HashSet<evento_empresa>();
            this.publicidad = new HashSet<publicidad>();
        }
    
        public int id { get; set; }
        public string correo { get; set; }
        public string contra { get; set; }
        public string nombre { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> id_categoria { get; set; }
        public Nullable<int> auto_usuario { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_subcategoria { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string coord_x { get; set; }
        public string coord_y { get; set; }
        public string imagen { get; set; }
        public Nullable<int> nit { get; set; }
        public string nombre_nit { get; set; }
        public Nullable<int> id_metodo_pago { get; set; }
        public string nro_cuenta { get; set; }
        public int valido { get; set; }
    
        public virtual categoria_empresa categoria_empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evento_empresa> evento_empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<publicidad> publicidad { get; set; }
    }
}
