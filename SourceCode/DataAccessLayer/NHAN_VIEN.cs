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
    
    public partial class NHAN_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAN_VIEN()
        {
            this.BAO_CAO = new HashSet<BAO_CAO>();
            this.DAT_PHONG = new HashSet<DAT_PHONG>();
            this.DOI_PHONG = new HashSet<DOI_PHONG>();
            this.HOA_DON = new HashSet<HOA_DON>();
        }
    
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MaChucVu { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> Luong { get; set; }
        public string NguonAnh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAO_CAO> BAO_CAO { get; set; }
        public virtual CHUC_VU CHUC_VU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAT_PHONG> DAT_PHONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOI_PHONG> DOI_PHONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA_DON> HOA_DON { get; set; }
        public virtual TAI_KHOAN TAI_KHOAN { get; set; }
    }
}
