namespace CodeMasterDev.Core.Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public int DiretorId { get; set; }
    public Director? Director { get; set; }
    public ICollection<ActorMovie>? ActorMovies { get; set; }
    
}