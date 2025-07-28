using LibrayAPI.Models;
using LibrayAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _repo;

        public MemberController(IMemberRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var member = await _repo.GetByIdAsync(id);
            return member is null ? NotFound() : Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            await _repo.CreateAsync(member);
            return CreatedAtAction(nameof(Get), new { id = member.MemberId }, member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Member member)
        {
            if (id != member.MemberId) return BadRequest("ID mismatch");
            await _repo.UpdateAsync(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetBooks(int id) =>
       Ok(await _repo.GetBooksByMemberAsync(id));
    }
}
