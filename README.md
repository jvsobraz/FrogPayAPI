# FrogPayAPI

<h1 align="center">
  Implementação Backend
</h1>

<p align="center">
 <img src="https://img.shields.io/static/v1?label=Tipo&message=Projeto&color=8257E5&labelColor=000000" alt="Desafio" />
</p>

Neste projeto você deverá implementar uma API REST disponibilizando o artefato final conforme
orientações deste documento.
A solução deverá basear-se no seguinte diagrama de banco de dados:

![alt text](<Projeto Backend.jpg>)


## Descrição dos Arquivos e Pastas

# Controllers/

PessoaController.cs: Controlador que gerencia as operações CRUD para a entidade Pessoa.
DadosBancariosController.cs: Controlador que gerencia as operações CRUD para a entidade DadosBancarios.
EnderecoController.cs: Controlador que gerencia as operações CRUD para a entidade Endereco.
LojaController.cs: Controlador que gerencia as operações CRUD para a entidade Loja.

# Data/
FrogPayContext.cs: Contexto do Entity Framework que configura as entidades e suas relações com o banco de dados.

# Models/
Pessoa.cs: Modelo que representa a entidade Pessoa.
DadosBancarios.cs: Modelo que representa a entidade DadosBancarios.
Endereco.cs: Modelo que representa a entidade Endereco.
Loja.cs: Modelo que representa a entidade Loja.

# Properties/
launchSettings.json: Arquivo de configuração para perfis de lançamento durante o desenvolvimento.

# Raiz do Projeto
FrogPayAPI.csproj: Arquivo de configuração do projeto, definindo dependências e configurações do build.
Program.cs: Ponto de entrada da aplicação, onde a aplicação web é configurada e inicializada.
appsettings.json: Arquivo de configuração para definições de ambiente como strings de conexão e outras configurações gerais.
appsettings.Development.json: Configuração específica para o ambiente de desenvolvimento.

## Tecnologias
 
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore
- xunit

## Práticas adotadas

- API REST
- Geração automática do Swagger com a OpenAPI 3

## Como Executar

- Clonar repositório git
- Configurar o Banco de Dados (FrogPayContext.cs)
- 

## Endpoints

- Criar Pessoa
```
$ http POST

public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.IdPessoa }, pessoa);
        }
```

- Listar Pessoas
```
$ http GET

[HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }
```

- Atualizar Pessoas
```
$ http PUT

[HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.IdPessoa)
            {
                return BadRequest();
            }
            _context.Entry(pessoa).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
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
```

- Remover Pessoas
```
http DELETE

[HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoas.Any(e => e.IdPessoa == id);
        }
```

## Como Executar

1. Clone o repositório: `git clone https://github.com/jvsobraz/FrogPayAPI.git`
2. Navegue para a pasta do projeto: `cd FrogPayAPI`
3. Execute a aplicação: `dotnet run`
4. Acesse a API em `https://localhost:5001/api/pessoas`

## Testes

Para rodar os testes, execute: `dotnet test`
