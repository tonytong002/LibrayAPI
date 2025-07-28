using LibrayAPI.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace LibrayAPI.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IConfiguration _config;

        public MemberRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection CreateConnection() =>
            new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Member>("SELECT * FROM Members");
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Member>(
                "SELECT * FROM Members WHERE MemberId = @Id", new { Id = id });
        }

        public async Task CreateAsync(Member member)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                "INSERT INTO Members (Name, Email) VALUES (@Name, @Email)", member);
        }

        public async Task UpdateAsync(Member member)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                "UPDATE Members SET Name = @Name, Email = @Email WHERE MemberId = @MemberId", member);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync("DELETE FROM Members WHERE MemberId = @Id", new { Id = id });
        }

        public async Task<IEnumerable<Book>> GetBooksByMemberAsync(int memberId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Book>(@"
                SELECT b.* FROM Books b
                INNER JOIN MemberBooks mb ON b.BookId = mb.BookId
                WHERE mb.MemberId = @MemberId", new { MemberId = memberId });
        }

    }
}

