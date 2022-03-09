using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CreateUserLibrary.BusinessLogic
{
    internal class Utils
    {
        public static Dictionary<string, List<string>> ExtractErrorFromWebApiResponse(string body)
        {
            var response = new Dictionary<string, List<string>>();
            var jsonElement=JsonSerializer.Deserialize<JsonElement>(body);
            var errorjsonElement = jsonElement.GetProperty("errors");
            foreach (var fieldwitherrors in errorjsonElement.EnumerateObject())
            {
                var field = fieldwitherrors.Name;
                var errors=new List<string>();
                foreach (var errorkind in fieldwitherrors.Value.EnumerateArray())
                {
                    var error = errorkind.GetString();
                    errors.Add(error);
                }
                response.Add(field, errors);
            }
            return response;
        }
    }
}
