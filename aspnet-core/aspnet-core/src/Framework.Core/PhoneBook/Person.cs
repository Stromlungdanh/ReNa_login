using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Framework.PhoneBook
{
    [Table("Persons")]
    public class Person : FullAuditedEntity
    {
        [Required]
        [MaxLength(PersonConst.MaxNameLength)]
        public virtual string Name { get; set; }


        [Required]
        [MaxLength(PersonConst.MaxSurNameLength)]
        public virtual string SurName { get; set; }

        [Required]
        [MaxLength(PersonConst.MaxEmailLength)]
        public virtual string EmailAddress { get; set; }
    }
}
