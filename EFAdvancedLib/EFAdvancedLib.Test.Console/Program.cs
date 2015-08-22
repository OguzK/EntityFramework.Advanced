using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFAdvancedLib.Extensions;
using System.Data.SqlClient;
using System.Diagnostics;
using EntityFramework.BulkInsert.Extensions;

namespace EFAdvancedLib.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestDbEntities())
            {
                List<EnrouteDatalari> list = new List<EnrouteDatalari>();
                Random rnd = new Random();
                for (int i = 0; i < 750000; i++)
                {
                    list.Add(new EnrouteDatalari
                    {
                        Birthday = DateTime.Now,
                        Hit = i * 2,
                        IsDraft = Convert.ToBoolean(rnd.Next(0, 1)),
                        Name = string.Concat("Name - ", i),
                        Surname = string.Concat("Surname - ", i)
                    });

                }

                Stopwatch sw = new Stopwatch();
                sw.Start();
                System.Console.WriteLine("Started : {0}", DateTime.Now.ToLongTimeString());
                db.EnrouteDatalari.BulkInsert(list, db, new BulkInsertOptions() { });
                sw.Stop();
                System.Console.WriteLine("Stopped : {0} - Elapset : {1}", DateTime.Now.ToLongTimeString(), sw.ElapsedMilliseconds);
                System.Console.ReadLine();
            }
        }
    }
}
