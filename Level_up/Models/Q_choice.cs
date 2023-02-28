namespace Level_up.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Q_choice
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Q_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string multchoice { get; set; }

        public virtual Quction Quction { get; set; }
    }
}
