using System.Text;
using System.Text.Json;
using HealthComp.myCare.BulkUploadAdmins.Abstractions;
using HealthComp.myCare.BulkUploadAdmins.Models;
using Microsoft.Extensions.Logging;

namespace HealthComp.myCare.BulkUploadAdmins.Services;

public class RegisterAdminService: IRegisterAdminService
{
    private readonly ILogger<RegisterAdminService> _logger;
    public RegisterAdminService(ILogger<RegisterAdminService> logger)
    {
        _logger = logger;
    }
    public async Task RegisterAdmin(IList<User> admins)
    {
        foreach (var admin in admins)
        {
            _logger.LogDebug($"Making POST request for username: {admin.UserName}");
            
            var json = JsonSerializer.Serialize(admin);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = Constants.Constants.RegisterAdminEndpoint; 
            using var client = new HttpClient();
            
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Constants.Constants.BearerToken}");

            var response = await client.PostAsync(url, data);

            string result = await response.Content.ReadAsStringAsync();
            
            _logger.LogDebug($"Post request completed for username: {admin.UserName}");
            _logger.LogDebug($"Result : {result}");
        }
    }
}