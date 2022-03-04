using CloudCustomers.API.Models;
using System;


public interface IUsersService
{
    public Task<List<User>> GetAlUsers();
    
}
public class UserService : IUsersService{
    private readonly HttpClient _httpClient;

    public UsersService(HttpClient httpClient){
        _httpClient = httpClient;
    }
    public async Task<List<Users>> GetAlUsers(){
        var usersResponse = await _httpClient.GetAsync("https://example");
        if(usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound){
            return new List<User>();
        }
        var responseContent = usersResponse.Content;
        var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
        return allUsers.ToList();
    }
    
}