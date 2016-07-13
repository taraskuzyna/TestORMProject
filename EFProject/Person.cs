using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
    [Table("PEOPLE")]
    public class Person
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("FIRSTNAME")]
        public String FirstName { get; set; }

        [Column("LASTNAME")]
        public String LastName { get; set; }

        [Column("DATEOFBIRTH")]
        public DateTime? DateOfBirth { get; set; }

        [Column("TELEPHONE")]
        public string Telephone { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("GENDER")]
        public Gender? Gender { get; set; }

        [Column("ADDRESS_ID")]
        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
