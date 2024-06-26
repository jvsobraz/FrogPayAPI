using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrogPayAPI.Models;
using FrogPayAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class DadosBancariosController : ControllerBase
{
    private readonly FrogPayContext _context;

    public DadosBancariosController(FrogPayContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DadosBancarios>>> GetDadosBancarios()
    {
        return await _context.DadosBancarios.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DadosBancarios>> GetDadosBancarios(int id)
    {
        var dadosBancarios = await _context.DadosBancarios.FindAsync(id);
        if (dadosBancarios == null)
        {
            return NotFound();
        }
        return dadosBancarios;
    }

    [HttpPost]
    public async Task<ActionResult<DadosBancarios>> PostDadosBancarios(DadosBancarios dadosBancarios)
    {
        _context.DadosBancarios.Add(dadosBancarios);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDadosBancarios), new { id = dadosBancarios.IdDadosBancarios }, dadosBancarios);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDadosBancarios(int id, DadosBancarios dadosBancarios)
    {
        if (id != dadosBancarios.IdDadosBancarios)
        {
            return BadRequest();
        }
        _context.Entry(dadosBancarios).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DadosBancariosExists(id))
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
    public async Task<IActionResult> DeleteDadosBancarios(int id)
    {
        var dadosBancarios = await _context.DadosBancarios.FindAsync(id);
        if (dadosBancarios == null)
        {
            return NotFound();
        }
        _context.DadosBancarios.Remove(dadosBancarios);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool DadosBancariosExists(int id)
    {
        return _context.DadosBancarios.Any(e => e.IdDadosBancarios == id);
    }
}
