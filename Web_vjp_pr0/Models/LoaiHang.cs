//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_vjp_pr0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiHang()
        {
            this.ThongTinHangs = new HashSet<ThongTinHang>();
        }
    
        public string MaLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinHang> ThongTinHangs { get; set; }
    }
}
