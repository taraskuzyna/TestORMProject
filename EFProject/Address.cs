using System.ComponentModel.DataAnnotations.Schema;

namespace EFProject
{
    [Table("ADDRESSES")]
    public class Address
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("REGION")]
        public string Region { get; set; }

        [Column("CITY")]
        public string City { get; set; }

        [Column("STREET")]
        public string Street { get; set; }

        [Column("HOUSENUMBER")]
        public string HouseNumber { get; set; }

        [Column("FLATNUMBER")]
        public string FlatNumber { get; set; }

        [Column("ZIPCODE")]
        public string ZipCode { get; set; }

        [Column("LONGITUDE")]
        public double Longitude { get; set; }

        [Column("LATITUDE")]
        public double Latitude { get; set; }
    }
}
