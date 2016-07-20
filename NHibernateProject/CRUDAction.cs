using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateProject
{
    public class CRUDAction
    {
        public void Create()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var list = GenerateListOfPersons();
                    foreach (Person item in list)
                        session.Save(item);

                    transaction.Commit();
                }
            }
        }

        public void Read()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                List<Person> list = session.CreateCriteria<Person>().List<Person>().ToList();
            }
        }

        public void Update()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    List<Person> list = session.CreateCriteria<Person>().List<Person>().ToList();
                    foreach (Person item in list)
                    {
                        item.Email += ".pl";
                        session.Update(item);
                    }
                    transaction.Commit();
                }
            }
        }

        public void Delete()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    List<Person> list = session.CreateCriteria<Person>().List<Person>().ToList();
                    foreach (Person item in list)
                    {
                        session.Delete(item);
                    }
                    transaction.Commit();
                }
            }
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
