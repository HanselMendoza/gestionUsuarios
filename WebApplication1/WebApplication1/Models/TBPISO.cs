//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBPISO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBPISO()
        {
            this.TBCOORDENADAs = new HashSet<TBCOORDENADA>();
            this.TBDEPARTAMENTOes = new HashSet<TBDEPARTAMENTO>();
        }
    
        public int IDPISO { get; set; }
        public Nullable<int> IDESTADO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBCOORDENADA> TBCOORDENADAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDEPARTAMENTO> TBDEPARTAMENTOes { get; set; }
        public virtual TBESTADO TBESTADO { get; set; }
    }
}
