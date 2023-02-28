namespace Level_up.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class R_book
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonIgnore]
        public int R_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string book { get; set; }
        [JsonIgnore]
        public virtual Resource Resource { get; set; }
    }
}
