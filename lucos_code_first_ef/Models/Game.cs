using System.Numerics;
using System.Text.Json.Serialization;

namespace lucos_code_first_ef.Models
{
    public class Game
    {
        // Primary Key
        public Guid Id { get; set; }

        // Foreign Keys
        //[JsonIgnore]
        public Player PlayerW { get; set; }   // 1 player of white
        //[JsonIgnore]
        public Player PlayerB { get; set; }   // 1 player of black
        //[JsonIgnore]
        public Opening Opening { get; set; }  // chess opening played

        // Non-Key Attributes
        public DateOnly Date { get; set; }
        public string Result { get; set; }
    }
}
