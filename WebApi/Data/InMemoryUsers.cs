using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Persistence;

namespace WebApi.Data
{
    public class InMemoryUserService : IUserService
    {
        private AdultContext ctx;

        public InMemoryUserService(AdultContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IList<User>> allUsersAsync()
        {
            return await ctx.Users.ToListAsync();
        }


        public async Task<User> ValidateUser(string userName, string passWord)
        {
            User user = ctx.Users.FirstOrDefault(u => u.username.Equals(userName) && u.password.Equals(passWord));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }
    }
}