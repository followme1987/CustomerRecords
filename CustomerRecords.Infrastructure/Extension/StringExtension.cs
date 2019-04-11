using CustomerRecords.Domain;
using Newtonsoft.Json;

namespace CustomerRecords.Infrastructure.Extension
{
    public static class StringExtension
    {
        public static Customer DeserializeJsonStringToObj(this string jsonString)
        {
            return JsonConvert.DeserializeObject<Customer>(jsonString);
        }
    }
}