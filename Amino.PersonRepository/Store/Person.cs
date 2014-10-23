namespace Amino.PersonsRepository.Store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [Key]
        public Guid DomainId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(200)]
        public string Lastname { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        public Guid ZipCodeFk { get; set; }

        public virtual ZipCode ZipCode { get; set; }
    }
}
