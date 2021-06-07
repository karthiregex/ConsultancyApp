namespace EntityDataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentAddress")]
    public partial class StudentAddress
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [StringLength(150)]
        public string Address1 { get; set; }

        [Required]
        [StringLength(150)]
        public string Address2 { get; set; }

        [StringLength(100)]
        public string City { get; set; }
    }
}
