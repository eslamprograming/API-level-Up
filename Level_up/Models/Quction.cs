namespace Level_up.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quction")]
    public partial class Quction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quction()
        {
            Cat_Level_Quction = new HashSet<Cat_Level_Quction>();
            Q_choice = new HashSet<Q_choice>();
        }

        [Key]
        public int Q_ID { get; set; }

        public string L_Q { get; set; }

        public string anseur { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cat_Level_Quction> Cat_Level_Quction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Q_choice> Q_choice { get; set; }
    }
}
