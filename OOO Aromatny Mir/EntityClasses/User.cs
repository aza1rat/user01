namespace OOO_Aromatny_Mir.EntityClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserSurname { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPatronymic { get; set; }

        [Required]
        [StringLength(60)]
        public string UserLogin { get; set; }

        [Required]
        [StringLength(30)]
        public string UserPassword { get; set; }

        public int UserRole { get; set; }

        [Column(TypeName = "image")]
        public byte[] UserPhoto { get; set; }
    }
}
