using EverestORM.Attributes;

namespace ADOProject
{
    [DbTableAttr("ADDRESSES")]
    public class Address
    {
        [DbPrimaryKeyAttr]
        [DbColumnAttr("ID")]
        public int Id { get; set; }

        [DbColumnAttr("REGION")]
        public string Region { get; set; }

        [DbColumnAttr("CITY")]
        public string City { get; set; }

        [DbColumnAttr("STREET")]
        public string Street { get; set; }

        [DbColumnAttr("HOUSENUMBER")]
        public string HouseNumber { get; set; }

        [DbColumnAttr("FLATNUMBER")]
        public string FlatNumber { get; set; }

        [DbColumnAttr("ZIPCODE")]
        public string ZipCode { get; set; }

        [DbColumnAttr("LONGITUDE")]
        public double Longitude { get; set; }

        [DbColumnAttr("LATITUDE")]
        public double Latitude { get; set; }
    }
}
