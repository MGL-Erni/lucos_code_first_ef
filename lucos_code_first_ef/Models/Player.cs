namespace lucos_code_first_ef.Models
{
    public class Player
    {
        // Primary Key
        public Guid Id { get; set; }

        // Non-Key Attributes
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public int PlayerRating { get; set; }
    }
}
