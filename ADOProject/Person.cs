using EverestORM.Attributes;
using System;

namespace ADOProject
{
    [DbTableAttr("PEOPLE")]
    public class Person
    {
        [DbPrimaryKeyAttr]
        [DbColumnAttr("ID")]
        public int Id { get; set; }

        [DbColumnAttr("FIRSTNAME")]
        public String FirstName { get; set; }

        [DbColumnAttr("LASTNAME")]
        public String LastName { get; set; }

        [DbColumnAttr("DATEOFBIRTH")]
        public DateTime DateOfBirth { get; set; }

        [DbColumnAttr("TELEPHONE")]
        public string Telephone { get; set; }

        [DbColumnAttr("EMAIL")]
        public string Email { get; set; }

        [DbColumnAttr("GENDER")]
        public int Gender { get; set; }

        [DbColumnAttr("ADDRESS_ID")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }

    public enum Gender : int
    {
        Male,
        Female
    }
}
