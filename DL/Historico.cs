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
    
    public partial class Historico
    {
        public int IdHistorico { get; set; }
        public Nullable<int> IdProceso { get; set; }
        public Nullable<byte> IdFiltro { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string Detalle { get; set; }
    
        public virtual Filtro Filtro { get; set; }
        public virtual Proceso Proceso { get; set; }
    }
}