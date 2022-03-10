using CreateUserLibrary.Interfaces;
using CreateUserLibrary.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateUserLibrary.BusinessLogic
{
    public class CreateUser : ICreateUser
    {
        public async Task CreateNewUser()
        {
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var url = "http://localhost:50689/api/User/registration/";

            using (var httpclient = new HttpClient())
            {
                try
                {
                    RegistrationForm Registration = new RegistrationForm() { DisplayName = "Sergey", UserName = "Serg", Email = "test@test.com", Password = "2wsx@WSX" };
                    var RegistrationSerialized = JsonSerializer.Serialize(Registration);
                    var Content = new StringContent(RegistrationSerialized, Encoding.UTF8, "application/json");
                    var Response = await httpclient.PostAsync(url, Content);

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


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

            };








        }
    }
}
