namespace CodeMasterDev.Core.Models;

public class Director
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string? Nationality { get; set; }
    public ICollection<Movie>? Films { get; set; }
}