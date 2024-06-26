using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrogPayAPI.Models;
using FrogPayAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class LojaController : ControllerBase
{
    private readonly FrogPayContext _context;

    public LojaController(FrogPayContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loja>>> GetLojas()
    {
        return await _context.Lojas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Loja>> GetLoja(int id)
    {
        var loja = await _context.Lojas.FindAsync(id);
        if (loja == null)
        {
            return NotFound();
        }
        return loja;
    }

    [HttpPost]
    public async Task<ActionResult<Loja>> PostLoja(Loja loja)
    {
        _context.Lojas.Add(loja);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLoja), new { id = loja.IdLoja }, loja);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLoja(int id, Loja loja)
    {
        if (id != loja.IdLoja)
        {
            return BadRequest();
        }
        _context.Entry(loja).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LojaExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoja(int id)
    {
        var loja = await _context.Lojas.FindAsync(id);
        if (loja == null)
        {
            return NotFound();
        }
        _context.Lojas.Remove(loja);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool LojaExists(int id)
    {
        return _context.Lojas.Any(e => e.IdLoja == id);
    }
}
