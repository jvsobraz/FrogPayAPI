[HttpGet("{id}/detalhes")]
public async Task<ActionResult<PessoaDetalhesDTO>> GetPessoaDetalhes(int id)
{
    var pessoa = await _context.Pessoas
        .Include(p => p.DadosBancarios)
        .Include(p => p.Enderecos)
        .FirstOrDefaultAsync(p => p.Id == id);

    if (pessoa == null)
    {
        return NotFound();
    }

    return new PessoaDetalhesDTO
    {
        Nome = pessoa.Nome,
        DadosBancarios = pessoa.DadosBancarios,
        Enderecos = pessoa.Enderecos
    };
}
