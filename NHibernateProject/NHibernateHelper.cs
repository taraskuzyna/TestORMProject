using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateProject
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    BuildSessionFactory();
                return _sessionFactory;
            }
        }

        static void BuildSessionFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["fb1"].ConnectionString;
           
            FirebirdConfiguration cfg = new FirebirdConfiguration()
                .ConnectionString(connectionString)
                .AdoNetBatchSize(100);

            _sessionFactory = Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.Add(typeof(PersonMap)))
                .Mappings(m => m.FluentMappings.Add(typeof(AddressMap)))
                //.ExposeConfiguration(BuildSchema)
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        //static void BuildSchema(Configuration cfg)
        //{
        //    new SchemaExport(cfg).Create(false, true);
        //}

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
