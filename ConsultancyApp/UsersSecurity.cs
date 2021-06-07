namespace ConsultancyApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersSecurity")]
    public partial class UsersSecurity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(50)]
        public string UserRole { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }
    }
}
