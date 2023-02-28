namespace Level_up.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            cat_E_u = new HashSet<cat_E_u>();
            Cat_Level_User = new HashSet<Cat_Level_User>();
            user_degree = new HashSet<user_degree>();
        }

        [Key]
        public int u_ID { get; set; }

        [StringLength(10)]
        public string first_name { get; set; }

        [StringLength(10)]
        public string last_name { get; set; }

        public int? age { get; set; }

        public string email { get; set; }

        [StringLength(16)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cat_E_u> cat_E_u { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cat_Level_User> Cat_Level_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_degree> user_degree { get; set; }
    }
}
