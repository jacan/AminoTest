namespace Amino.PersonsRepository.Store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ZipCode")]
    public partial class ZipCode
    {
        public ZipCode()
        {
            People = new HashSet<Person>();
        }

        [Key]
        public Guid DomainId { get; set; }

        [Column("ZipCode")]
        [Required]
        [StringLength(50)]
        public string ZipCode1 { get; set; }

        [Required]
        [StringLength(500)]
        public string City { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
