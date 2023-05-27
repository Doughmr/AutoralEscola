using Microsoft.Extensions.Hosting;

public class Matricula
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Number { get; set; }
    public string? Content { get; set; }

    public int AlunoId { get; set; }
    public int UnifoaId { get; set; }
    public ICollection<Matricula>? Matriculas { get; }
}