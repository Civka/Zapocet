using System.Text.Json.Serialization;

namespace Zapocet.Data.Dto
{
    public class GenericResponseDto
    {
        public int? Success { get; set; } = 0;
        public int? Failed { get; set; } = 0;

        public List<string> FailedList { get; set; } = new List<string>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
    }
}
