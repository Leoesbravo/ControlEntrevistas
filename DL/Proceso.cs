//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proceso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proceso()
        {
            this.Historicoes = new HashSet<Historico>();
        }
    
        public int IdProceso { get; set; }
        public Nullable<byte> IdEstatus { get; set; }
        public Nullable<byte> IdBolsaTrabajo { get; set; }
        public string NumeroContacto { get; set; }
        public string Empresa { get; set; }
        public string Cliente { get; set; }
        public string LigaVacante { get; set; }
        public Nullable<bool> Postulado { get; set; }
        public Nullable<System.DateTime> FechaContacto { get; set; }
        public Nullable<int> IdRecurso { get; set; }
    
        public virtual BolsaTrabajo BolsaTrabajo { get; set; }
        public virtual Estatu Estatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historico> Historicoes { get; set; }
        public virtual Recurso Recurso { get; set; }
    }
}