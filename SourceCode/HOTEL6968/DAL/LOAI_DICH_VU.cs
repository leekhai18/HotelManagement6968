//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HOTEL6968.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOAI_DICH_VU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAI_DICH_VU()
        {
            this.DICH_VU = new HashSet<DICH_VU>();
        }
    
        public string MaLoaiDichVu { get; set; }
        public string TenLoaiDichVu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DICH_VU> DICH_VU { get; set; }
    }
}