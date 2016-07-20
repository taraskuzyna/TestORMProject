using SimpleDataProject;
using System;

namespace SimpleDataProject
{
    public class Person
    {
        public int? Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public Gender? Gender { get; set; }

        public int? AddressId { get; set; }

        public virtual Addresses Addresses { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
