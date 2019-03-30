using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CustomerRecords.Domain
{
    [DataContract]
    public class Customer : Position
    {
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "user_id")]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}