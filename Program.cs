using FilmesTerror.Data;
using FilmesTerror.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;
using System.IO;

using var context = new AppDbContext();

context.Database.EnsureCreated();

Console.WriteLine("🎬 Filmes de Terror a partir do ano 2000:\n");

var filmes = context.Filmes
    .Include(f => f.Genero)
    .Where(f => f.Genero.Nome == "Terror" && f.AnoLancamento >= 2000)
    .OrderBy(f => f.Titulo)
    .ToList();

if (filmes.Count == 0)
{
    Console.WriteLine("Nenhum filme encontrado.");
}
else
{
    Console.WriteLine($"Total de filmes encontrados: {filmes.Count}\n");
    foreach (var filme in filmes)
    {
        Console.WriteLine($"- {filme.Titulo} ({filme.AnoLancamento}) | Gênero: {filme.Genero.Nome}");
    }
}