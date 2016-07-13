using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateProject
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();

            Map(x => x.DateOfBirth);
            Map(x => x.Email);
            Map(x => x.FirstName);
            Map(x => x.Gender).CustomType<Gender>();
            Map(x => x.LastName);
            Map(x => x.Telephone);

            References(x => x.Address).Column("ADDRESS_ID").Cascade.All();

            Table("PEOPLE");
        }
    }
}