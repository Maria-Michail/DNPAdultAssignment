using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment.Data{
public class InMemoryUserService : IUserService {

    public InMemoryUserService() {
        
    }


    public async Task<User> ValidateUser(string username, string password) {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:5003/Users?username={username}&password={password}");
        if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }
        throw new Exception("User not found");
    }
}
}