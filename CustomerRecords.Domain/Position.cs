using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CustomerRecords.Domain
{
    [DataContract]
    public class Position
    {
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
    }
}