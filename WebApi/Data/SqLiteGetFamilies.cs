using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApi.Data
{
    public class SqLiteGetFamilies : IGetFamilies
    {
        private AdultContext ctx;

        public SqLiteGetFamilies(AdultContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IList<Adult>> allAdultsAsync()
        {
            return await ctx.Adults.ToListAsync();
        }

        public async Task addNewAdultAsync(Adult adult)
        {
            EntityEntry<Adult> newlyAdded = await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
            //return newlyAdded.Entity;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toDelete = await ctx.Adults.FirstOrDefaultAsync(t => t.Id == adultId);
            if (toDelete != null)
            {
                ctx.Adults.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task UpdateAdultAsync(Adult adult)
        {
            try
            {
                Adult toUpdate = await ctx.Adults.FirstAsync(t => t.Id == adult.Id);
                ctx.Update(toUpdate);
                await ctx.SaveChangesAsync();
                //return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find todo with id{adult.Id}");
            }
        }
    }
}