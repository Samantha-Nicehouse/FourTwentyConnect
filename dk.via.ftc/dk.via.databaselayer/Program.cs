using dk.via.databaselayer.Models;
using dk.via.ftc.web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.databaselayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            InsertIntoDB();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void InsertIntoDB()
        {
            using (var db = new DataContext())
            {
                // Creating a new item and saving it to the database
                var newItem = new Vendor();
                newItem.VendorId = 1;
                newItem.vendorLicense = "asdasd";
                newItem.VendorName = "VendorName";
                newItem.stateProvince = "State";
                newItem.City = "City";
                newItem.Country = "Country";
                db.Item.Add(newItem);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                // Retrieving and displaying data
                Console.WriteLine();
                Console.WriteLine("All items in the database:");
                foreach (var item in db.Item)
                {
                    Console.WriteLine("{0} | {1}", item.VendorId, item.VendorName);
                }
            }
        }
    }
}
