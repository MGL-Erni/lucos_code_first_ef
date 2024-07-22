namespace lucos_code_first_ef.Dto
{
    public class GameDTO
    {
        public Guid Id { get; set; }
        public PlayerDTO PlayerW { get; set; }   // Player playing white
        public PlayerDTO PlayerB { get; set; }   // Player playing black
        public OpeningDTO Opening { get; set; }  // Chess opening played
        public DateOnly Date { get; set; }
        public string Result { get; set; }
    }
}