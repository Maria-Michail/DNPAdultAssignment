using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using WebApi.Persistence;
using WebApi.Data;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (AdultContext adultContext = new AdultContext())
            {
                //adultContext.RemoveRange(adultContext.Adults);
                //adultContext.SaveChanges();   
                if (!adultContext.Adults.Any())
                {
                    Seed();
                }
            }
            using (AdultContext userContext = new AdultContext())
            {
                //adultContext.RemoveRange(adultContext.Adults);
                //adultContext.SaveChanges();   
                if (!userContext.Users.Any())
                {
                    SeedUsers();
                }
            }
            CreateHostBuilder(args).Build().Run();
           
            
        }
        private static void Seed()
        {
            IList<Adult> adults = DBSeeder.ReadJsonFromFile("adults.json");
            string famSerialized = JsonSerializer.Serialize(adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            DBSeeder.Seed(adults);
        }

        private static void SeedUsers()
        {
            IList<User> users = new[] {
                new User {
                    City = "Horsens",
                    Domain = "via.dk",
                    password = "123456",
                    Role = "Teacher",
                    BirthYear = 1986,
                    SecurityLevel = 5,
                    username = "Troels"
                },
                new User {
                    City = "Aarhus",
                    Domain = "hotmail.com",
                    password = "123456",
                    Role = "Student",
                    BirthYear = 1998,
                    SecurityLevel = 3,
                    username = "Jakob"
                },
                new User {
                    City = "Vejle",
                    Domain = "via.com",
                    password = "123456",
                    Role = "Guest",
                    BirthYear = 1973,
                    SecurityLevel = 1,
                    username = "Kasper"
                }
            }.ToList();
            
            DBSeeder.SeedUsers(users);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
