using Framework.PhoneBook;
using System.ComponentModel.DataAnnotations;

namespace Framework
{
    public class CreatePersonInput
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