using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateProject
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();

            Map(x => x.City);
            Map(x => x.FlatNumber);
            Map(x => x.HouseNumber);
            Map(x => x.Latitude);
            Map(x => x.Longitude);
            Map(x => x.Region);
            Map(x => x.Street);
            Map(x => x.ZipCode);

            Table("ADDRESSES");
        }
    }
}
