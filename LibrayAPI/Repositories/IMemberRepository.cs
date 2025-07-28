using LibrayAPI.Models;

namespace LibrayAPI.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task CreateAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(int id);
        Task<IEnumerable<Book>> GetBooksByMemberAsync(int memberId);
    }
}
