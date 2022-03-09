using CreateUserLibrary.Interfaces;
using CreateUserLibrary.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateUserLibrary.BusinessLogic
{
    public class CreateUser : ICreateUser
    {
        public async Task CreateNewUser()
        {

            using (var client = new HttpClient())
            {
                var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                string url = "http://localhost:52682/api/User/registration";
                var Registration = new RegistrationForm { DisplayName = "Sergey1", Email = "test1@test.com", Password = "2wsx@WSX", UserName = "Serg1" };
                var Response = await client.PostAsJsonAsync(url, Registration);
                
                if (Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var body = await Response.Content.ReadAsStringAsync();
                    var errorsFromWebAPI = Utils.ExtractErrorFromWebApiResponse(body);

                    foreach (var fieldwithErrors in errorsFromWebAPI)
                    {
                        Console.WriteLine($"-{fieldwithErrors.Key}");
                        foreach (var error in fieldwithErrors.Value)
                        {
                            Console.WriteLine($"  {error}");
                        }

                    }
                }

                var people = JsonSerializer.Deserialize<List<RegistrationForm>>(await client.GetStringAsync(url), jsonSerializerOptions);

            };




            
        }
    }
}
