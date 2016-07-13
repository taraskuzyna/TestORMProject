using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
    public class CRUDAction
    {
        private MyDbContext db;

        public CRUDAction()
        {
            db = new MyDbContext();
        }

        public void Create()
        {
            db.Persons.AddRange(GenerateListOfPersons());
            db.SaveChanges();
        }

        public void Read()
        {
            List<Person> list = db.Persons.Include("Address").ToList();
        }

        public void Update()
        {
            List<Person> list = db.Persons.ToList();
            foreach (Person item in db.Persons)
            {
                item.Email += ".pl";
                db.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
            }
            db.SaveChanges();
        }

        public void Delete()
        {
            List<Person> list = db.Persons.ToList();
            db.Persons.RemoveRange(list);
            db.SaveChanges();
        }

        List<Person> GenerateListOfPersons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                persons.Add(new Person()
                {
                    FirstName = "Jan" + i.ToString(),
                    LastName = "Kowalski" + i.ToString(),
                    DateOfBirth = DateTime.Now.AddHours(i),
                    Email = "test" + i.ToString() + "@test.com",
                    Gender = i % 2 == 1 ? Gender.Male : Gender.Female,
                    Telephone = (2 * i).ToString(),
                    Address = new Address()
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
