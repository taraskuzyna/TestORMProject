using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateProject
{
    public class Address
    {
        public virtual int Id { get; set; }

        public virtual string Region { get; set; }

        public virtual string City { get; set; }

        public virtual string Street { get; set; }

        public virtual string HouseNumber { get; set; }

        public virtual string FlatNumber { get; set; }

        public virtual string ZipCode { get; set; }

        public virtual double Longitude { get; set; }

        public virtual double Latitude { get; set; }
    }
}
