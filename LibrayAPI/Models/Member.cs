namespace LibrayAPI.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // TODO: Add navigation for checked out books (optional)
    }
}
