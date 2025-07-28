namespace LibrayAPI.Models
{
    public class MemberBook
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
