using System.Text.Json.Serialization;

namespace API_RPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3

    }
}