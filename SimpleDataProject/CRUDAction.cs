using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataProject
{
    public class CRUDAction
    {
        dynamic db;

        public CRUDAction()
        {
            db = Database.OpenNamedConnection("fb1");
        }

        public void Create()
        {
            foreach (Person item in GenerateListOfPersons())
            {
                var p = db.Addresses.Insert(item.Addresses);
                item.AddressId = p.Id;
                db.People.Insert(item);
            }
        }

        public void Read()
        {
            List<Person> list = db.People.All().WithAddresses();
        }

        public void Update()
        {
            List<Person> list = db.People.All();
            foreach (var item in list)
                db.People.UpdateById(Id: item.Id, Email: item.Email + ".pl");
        }

        public void Delete()
        {
            db.People.DeleteAll();
            db.Addresses.DeleteAll();
        }

        List<Person> GenerateListOfPersons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 1000; i++)
            {
                persons.Add(new Person()
                {
                    FirstName = "Jan" + i.ToString(),
                    LastName = "Kowalski" + i.ToString(),
                    DateOfBirth = DateTime.Now.AddHours(i),
                    Email = "test" + i.ToString() + "@test.com",
                    Gender = i % 2 == 1 ? Gender.Male : Gender.Female,
                    Telephone = (2 * i).ToString(),
                    Addresses = new Addresses()
                    {
                        City = "Wroclaw" + i.ToString(),
                        Region = "Dolnoslaskie" + i.ToString(),
                        Street = "Pilsuckiego" + i.ToString(),
                        HouseNumber = i.ToString(),
                        FlatNumber = i.ToString(),
                        ZipCode = i.ToString() + "-" + i.ToString(),
                        Latitude = Math.Sqrt(i),
                        Longitude = Math.Sqrt(i + 1)
                    }
                });
            }
            return persons;
        }
    }
}
