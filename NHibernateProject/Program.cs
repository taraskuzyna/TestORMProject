using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateProject
{
    class Program
    {
        static DateTime begin;
        static DateTime end;
        static CRUDAction crud;
        static TimeSpan timeSpan;

        static void Main(string[] args)
        {
            try
            {
                crud = new CRUDAction();

                begin = DateTime.Now;
                crud.Create();
                end = DateTime.Now;
                timeSpan = end - begin;
                Console.WriteLine("Create: " + timeSpan.ToString());

                begin = DateTime.Now;
                crud.Read();
                end = DateTime.Now;
                timeSpan = end - begin;
                Console.WriteLine("Read: " + timeSpan.ToString());

                begin = DateTime.Now;
                crud.Update();
                end = DateTime.Now;
                timeSpan = end - begin;
                Console.WriteLine("Update: " + timeSpan.ToString());

                begin = DateTime.Now;
                crud.Delete();
                end = DateTime.Now;
                timeSpan = end - begin;
                Console.WriteLine("Delete: " + timeSpan.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            finally
            {
                Console.WriteLine("Press ESC to exit");

                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {

                }
            }
        }
    }
}