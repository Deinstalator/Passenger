using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.DTO;
using Xunit;
using Microsoft.AspNetCore.TestHost;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                          .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";
            var user = await GetUserAsync(email);
            user.Email.Equals(email);
        }

        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "user1000@email.com";
            var response = await _client.GetAsync($"users/{email}");
            response.StatusCode.Equals(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("users", payload);
            response.StatusCode.Equals(HttpStatusCode.Created);
            response.Headers.Location.ToString().Equals($"users/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.Equals(request.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}