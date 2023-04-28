using System.Text.Json.Serialization;

namespace Zapocet.Data.Dto
{
    public class GenericResponseDto
    {
        public int? Success { get; set; } = 0;
        public int? Failed { get; set; } = 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
    }
}
