//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class DICH_VU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICH_VU()
        {
            this.CTHDs = new HashSet<CTHD>();
        }
    
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string MaLoaiDichVu { get; set; }
        public string TinhTrang { get; set; }
        public decimal GiaDichVu { get; set; }
        public string GhiChu { get; set; }
        public string NguonAnh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual LOAI_DICH_VU LOAI_DICH_VU { get; set; }
    }
}
