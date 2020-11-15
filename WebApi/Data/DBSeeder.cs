using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebApi.Persistence;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class DBSeeder
    {
        public static void Seed(IList<Adult> adults)
        {
            // CleanInterestObjects(families);

            Console.WriteLine("Add adults..");
            AddAdults(adults);
            Console.WriteLine("Done!");
        }

        public static void SeedUsers(IList<User> users)
        {
            // CleanInterestObjects(families);

            Console.WriteLine("Add users..");
            AddUsers(users);
            Console.WriteLine("Done!");
        }


        private static void AddAdults(IList<Adult> adults)
        {
            foreach (Adult adult in adults)
            {
                using (AdultContext fctxt = new AdultContext())
                {
                    Console.WriteLine(adult.ToString());
                    fctxt.Adults.AddAsync(adult);
                    fctxt.Entry(adult).State = EntityState.Added;
                    //fctxt.Entry(adult).State = EntityState.Detached;
                    fctxt.SaveChangesAsync();
                }
            }
        }

        private static void AddUsers(IList<User> users)
        {
            foreach (User user in users)
            {
                using (AdultContext fctxt = new AdultContext())
                {
                    Console.WriteLine(user.ToString());
                    fctxt.Users.AddAsync(user);
                    fctxt.Entry(user).State = EntityState.Added;
                    //fctxt.Entry(user).State = EntityState.Detached;
                    fctxt.SaveChangesAsync();
                }
            }
        }



        public static IList<Adult> ReadJsonFromFile(string path)
        {
            IList<Adult> adults;
            using (var jsonReader = File.OpenText(path))
            {
                adults = JsonSerializer.Deserialize<List<Adult>>(jsonReader.ReadToEnd());
            }

            return adults;
        }
    }
}