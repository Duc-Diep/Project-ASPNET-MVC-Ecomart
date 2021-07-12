namespace EcomartVietNam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
            Orders1 = new HashSet<Order>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string email { get; set; }

        [StringLength(11)]
        public string phone_number { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.Password)]
        [UIHint("Password")]
        public string password { get; set; }

        [NotMapped]
        [Required]
        [Compare("password")]
        public string confirm_password { get; set; }


        [StringLength(50)]
        public string full_name { get; set; }

        [StringLength(100)]
        public string address { get; set; }
        [UIHint("Role")]
        public int role { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders1 { get; set; }
    }
}
