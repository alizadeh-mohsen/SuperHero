using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SuperHero.API.Data;
using SuperHero.API.Data.Dto;

namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController(HeroContext _context, IMapper _mapper) : ControllerBase
    {
        // GET: api/Hero
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetHeroes()
        {
            try
            {
                var heros = await _context.Heroes.ToListAsync();

                var responseDto = new ResponseDto
                {
                    Result = _mapper.Map<IEnumerable<HeroDto>>(heros),
                };
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }


        // GET: api/Hero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetHero(string id)
        {
            try
            {
                var hero = await _context.Heroes.FindAsync(id);

                if (hero == null)
                {
                    return NotFound();
                }

                var responseDto = new ResponseDto
                {
                    Result = _mapper.Map<HeroDto>(hero),
                };
                return Ok(responseDto);
            }
            catch (Exception ex)
            {

                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }


        }

        // PUT: api/Hero/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(string id, Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeroExists(hero.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        // DELETE: api/Hero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(string id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(string id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}
