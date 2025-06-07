namespace FilmesTerror.Models;

public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int AnoLancamento { get; set; }

    public int GeneroId { get; set; }
    public Genero Genero { get; set; } = null!;

    public int? DiretorId { get; set; }
    public Diretor? Diretor { get; set; }
    public ICollection<FilmeAtor>? Atores { get; set; }
    public ICollection<Avaliacao>? Avaliacoes { get; set; }
}