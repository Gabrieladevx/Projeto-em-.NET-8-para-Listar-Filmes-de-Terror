# FilmesTerror

Projeto em .NET 8 para listar filmes de terror a partir do ano 2000, utilizando Entity Framework Core e banco de dados SQLite.

## Funcionalidades
- Consulta e exibição de filmes de terror cadastrados no banco.
- Banco de dados populado automaticamente com seed de filmes e gênero.
- Busca otimizada por título (índice).

## Como rodar o projeto
1. Certifique-se de ter o .NET 8 SDK instalado.
2. Clone ou baixe este repositório.
3. No terminal, navegue até a pasta do projeto e execute:
   ```sh
   dotnet run
   ```
4. O banco de dados `filmes.db` será criado automaticamente na primeira execução.

## Estrutura do Projeto
- `Program.cs`: Ponto de entrada da aplicação.
- `Data/AppDbContext.cs`: Contexto do Entity Framework, seed de dados e configuração do banco.
- `Models/Filme.cs` e `Models/Genero.cs`: Modelos das entidades.

## Requisitos
- .NET 8 SDK
- Não é necessário instalar SQL Server, pois o projeto usa SQLite.

## Observações
- Para resetar o banco, basta apagar o arquivo `filmes.db` e rodar novamente.
- O projeto é ideal para estudos de Entity Framework, SQLite e organização de seed de dados.

## Como visualizar e editar o banco de dados com DB Browser for SQLite

1. Baixe e instale o [DB Browser for SQLite](https://sqlitebrowser.org/dl/).
2. Abra o programa e clique em "Abrir Banco de Dados".
3. Selecione o arquivo `filmes.db` na pasta do projeto.
4. Use as abas "Browse Data" para visualizar e editar registros, e "Execute SQL" para rodar queries e views.

## Como exportar dados para CSV via C#

Adicione este exemplo ao seu projeto para exportar a tabela de filmes para um arquivo CSV:

```csharp
using (var context = new AppDbContext())
{
    var filmes = context.Filmes.ToList();
    using (var writer = new StreamWriter("filmes_export.csv"))
    {
        writer.WriteLine("Id,Titulo,AnoLancamento,GeneroId");
        foreach (var f in filmes)
            writer.WriteLine($"{f.Id},\"{f.Titulo}\",{f.AnoLancamento},{f.GeneroId}");
    }
}
```

Você pode adaptar para exportar outras tabelas ou incluir mais campos.

## Como criar a view de relatório

No DB Browser for SQLite, vá em "Execute SQL" e cole o conteúdo do arquivo `Scripts/vw_FilmesDetalhes.sql` para criar a view de detalhes dos filmes.

Depois, execute:
```sql
SELECT * FROM vw_FilmesDetalhes;
```
para ver o relatório completo.

---

Feito com ❤️ para fãs de filmes de terror!
