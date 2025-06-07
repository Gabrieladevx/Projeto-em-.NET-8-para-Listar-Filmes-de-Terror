namespace FilmesTerror.Models;

public class Avaliacao
{
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public Filme Filme { get; set; } = null!;
    public int Nota { get; set; } // 1 a 10
    public string? Comentario { get; set; }
    public DateTime Data { get; set; }
}
