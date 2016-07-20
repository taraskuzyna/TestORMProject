using EverestORM;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ADOProject
{
    public class CRUDAction
    {
        private IContext context;

        public CRUDAction()
        {
            context = new FbContext("fb1");
        }

        public void Create()
        {
            var list = GenerateListOfPersons();
            foreach (var item in list)
            {
                int id = context.Insert(item.Address);
                item.AddressId = id;
                context.Insert(item);
            }
        }

        public void Read()
        {
            List<Address> list = context.Select<Address>().ToList();
            List<Person> list1 = context.Select<Person>().ToList();
            foreach (var item in list1)
                item.Address = list.Where(c => c.Id == item.AddressId).FirstOrDefault();

        }

        public void Update()
        {
            List<Person> list = context.Select<Person>().ToList();
            foreach (Person item in list)
            {
                item.Email += ".pl";
                context.Update(item);
            }
        }

        public void Delete()
        {
            List<Person> list = context.Select<Person>().ToList();
            foreach( Person item in list)
                context.Delete<Person>(item.Id);
            
            List<Address> list1 = context.Select<Address>().ToList();
            foreach (Address item in list1)
                context.Delete<Person>(item.Id);
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
                    Gender = i % 2 == 1 ? (int)Gender.Male : (int)Gender.Female,
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
