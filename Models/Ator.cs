namespace FilmesTerror.Models;

public class Ator
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<FilmeAtor>? FilmesAtuados { get; set; }
}
