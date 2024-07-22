namespace lucos_code_first_ef.Dto
{
    public class PlayerDTO
    {
        public Guid Id { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public int PlayerRating { get; set; }
    }
}