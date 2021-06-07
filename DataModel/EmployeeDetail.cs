namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeDetail
    {
        [Key]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public int? PostionCode { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public int? Age { get; set; }

        [StringLength(500)]
        public string eAddress { get; set; }

        public bool? IsContract { get; set; }
    }
}
