using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateProject
{
    public class Person
    {
        public virtual int Id { get; set; }

        public virtual String FirstName { get; set; }

        public virtual String LastName { get; set; }

        public virtual DateTime? DateOfBirth { get; set; }

        public virtual string Telephone { get; set; }

        public virtual string Email { get; set; }

        public virtual Gender? Gender { get; set; }

        public virtual int? AddressId { get; set; }

        public virtual Address Address { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
