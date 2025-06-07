using Microsoft.EntityFrameworkCore;
using FilmesTerror.Models;

namespace FilmesTerror.Data;

public class AppDbContext : DbContext
{
    public DbSet<Filme> Filmes => Set<Filme>();
    public DbSet<Genero> Generos => Set<Genero>();
    public DbSet<Diretor> Diretores => Set<Diretor>();
    public DbSet<Ator> Atores => Set<Ator>();
    public DbSet<FilmeAtor> FilmesAtores => Set<FilmeAtor>();
    public DbSet<Avaliacao> Avaliacoes => Set<Avaliacao>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=filmes.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed de gênero
        modelBuilder.Entity<Genero>().HasData(
            new Genero { Id = 1, Nome = "Terror" }
        );

        // Seed de filmes em ordem alfabética, com GeneroId abaixo do AnoLancamento
        modelBuilder.Entity<Filme>().HasData(
            new Filme {
                Id = 6,
                Titulo = "A Entidade",
                AnoLancamento = 2012,
                GeneroId = 1
            },
            new Filme {
                Id = 8,
                Titulo = "Annabelle",
                AnoLancamento = 2014,
                GeneroId = 1
            },
            new Filme {
                Id = 3,
                Titulo = "Atividade Paranormal",
                AnoLancamento = 2007,
                GeneroId = 1
            },
            new Filme {
                Id = 5,
                Titulo = "Corra!",
                AnoLancamento = 2017,
                GeneroId = 1
            },
            new Filme {
                Id = 4,
                Titulo = "Hereditário",
                AnoLancamento = 2018,
                GeneroId = 1
            },
            new Filme {
                Id = 2,
                Titulo = "Invocação do Mal",
                AnoLancamento = 2013,
                GeneroId = 1
            },
            new Filme {
                Id = 7,
                Titulo = "It: A Coisa",
                AnoLancamento = 2017,
                GeneroId = 1
            },
            new Filme {
                Id = 9,
                Titulo = "Midsommar",
                AnoLancamento = 2019,
                GeneroId = 1
            },
            new Filme {
                Id = 1,
                Titulo = "O Chamado",
                AnoLancamento = 2002,
                GeneroId = 1
            },
            new Filme {
                Id = 10,
                Titulo = "Sobrenatural",
                AnoLancamento = 2010,
                GeneroId = 1
            }
        );

        // Seed de diretores
        modelBuilder.Entity<Diretor>().HasData(
            new Diretor { Id = 1, Nome = "James Wan" },
            new Diretor { Id = 2, Nome = "Ari Aster" }
        );

        // Seed de atores
        modelBuilder.Entity<Ator>().HasData(
            new Ator { Id = 1, Nome = "Vera Farmiga" },
            new Ator { Id = 2, Nome = "Patrick Wilson" },
            new Ator { Id = 3, Nome = "Florence Pugh" }
        );

        // Seed de filmes-atores (relacionamento N:N)
        modelBuilder.Entity<FilmeAtor>().HasData(
            new FilmeAtor { FilmeId = 2, AtorId = 1 }, // Invocação do Mal - Vera Farmiga
            new FilmeAtor { FilmeId = 2, AtorId = 2 }, // Invocação do Mal - Patrick Wilson
            new FilmeAtor { FilmeId = 9, AtorId = 3 }  // Midsommar - Florence Pugh
        );

        // Seed de avaliações
        modelBuilder.Entity<Avaliacao>().HasData(
            new Avaliacao { Id = 1, FilmeId = 2, Nota = 9, Comentario = "Assustador e bem dirigido!", Data = new DateTime(2020, 10, 31) },
            new Avaliacao { Id = 2, FilmeId = 9, Nota = 8, Comentario = "Atmosfera única.", Data = new DateTime(2021, 5, 15) }
        );

        // Relacionamento Filme-Diretor (1:N)
        modelBuilder.Entity<Filme>()
            .HasOne<Diretor>()
            .WithMany(d => d.Filmes)
            .HasForeignKey("DiretorId")
            .OnDelete(DeleteBehavior.SetNull);

        // Relacionamento Filme-Ator (N:N)
        modelBuilder.Entity<FilmeAtor>()
            .HasKey(fa => new { fa.FilmeId, fa.AtorId });
        modelBuilder.Entity<FilmeAtor>()
            .HasOne(fa => fa.Filme)
            .WithMany()
            .HasForeignKey(fa => fa.FilmeId);
        modelBuilder.Entity<FilmeAtor>()
            .HasOne(fa => fa.Ator)
            .WithMany(a => a.FilmesAtuados)
            .HasForeignKey(fa => fa.AtorId);

        // Relacionamento Filme-Avaliacao (1:N)
        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Filme)
            .WithMany()
            .HasForeignKey(a => a.FilmeId);

        // Índice para busca mais rápida por título
        modelBuilder.Entity<Filme>()
            .HasIndex(f => f.Titulo);
    }
}