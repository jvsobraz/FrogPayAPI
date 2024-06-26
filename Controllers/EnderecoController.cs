using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrogPayAPI.Models;
using FrogPayAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly FrogPayContext _context;

    public EnderecoController(FrogPayContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecos()
    {
        return await _context.Enderecos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Endereco>> GetEndereco(int id)
    {
        var endereco = await _context.Enderecos.FindAsync(id);
        if (endereco == null)
        {
            return NotFound();
        }
        return endereco;
    }

    [HttpPost]
    public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEndereco), new { id = endereco.IdEndereco }, endereco);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
    {
        if (id != endereco.IdEndereco)
        {
            return BadRequest();
        }
        _context.Entry(endereco).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EnderecoExists(id))
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
    public async Task<IActionResult> DeleteEndereco(int id)
    {
        var endereco = await _context.Enderecos.FindAsync(id);
        if (endereco == null)
        {
            return NotFound();
        }
        _context.Enderecos.Remove(endereco);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool EnderecoExists(int id)
    {
        return _context.Enderecos.Any(e => e.IdEndereco == id);
    }

    [HttpGet("buscar/{nome}")]
    public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecoPorNome(string nome)
    {
        var enderecos = await _context.Enderecos
            .Include(e => e.Pessoa)
            .Where(e => e.Pessoa.Nome.Contains(nome))
            .ToListAsync();

        if (!enderecos.Any())
        {
            return NotFound();
        }

            return enderecos;
    }

}
