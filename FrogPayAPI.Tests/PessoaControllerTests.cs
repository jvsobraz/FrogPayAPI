using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FrogPayAPI.Controllers;
using FrogPayAPI.Data;
using FrogPayAPI.Models;

public class PessoaControllerTests
{
    private readonly FrogPayContext _context;
    private readonly PessoaController _controller;

    public PessoaControllerTests()
    {
        var options = new DbContextOptionsBuilder<FrogPayContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new FrogPayContext(options);
        _controller = new PessoaController(_context);
    }

    [Fact]
    public async Task GetPessoas_ReturnsListOfPessoas()
    {
        _context.Pessoas.Add(new Pessoa { Nome = "Teste", CPF = "12345678901", DataNascimento = DateTime.Now });
        await _context.SaveChangesAsync();

        var result = await _controller.GetPessoas();

        var actionResult = Assert.IsType<ActionResult<IEnumerable<Pessoa>>>(result);
        var pessoas = Assert.IsAssignableFrom<IEnumerable<Pessoa>>(actionResult.Value);
        Assert.Single(pessoas);
    }
}