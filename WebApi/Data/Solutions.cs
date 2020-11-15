using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Persistence;

namespace WebApi.Data
{
    public class Solutions
    {
        public void RunSolutions()
        {
            using (AdultContext ctx = new AdultContext())
            {
                HowManyAdultsHaveBlackHair(ctx);
            }
        }

        private void HowManyAdultsHaveBlackHair(AdultContext ctx)
        {
            var result = ctx.Adults.
                Where(adult => 
                    adult.HairColor.Equals("Black")).
                ToList();
            Console.WriteLine(result.Count);
        }

    }
}