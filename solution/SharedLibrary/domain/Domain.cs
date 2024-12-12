namespace SharedLibrary.Domain;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Team { get; set; }
    public string Position { get; set; }
    public int GamesPlayed { get; set; }
    public double AveragePoints { get; set; }
    public double CurrentPoints { get; set; }
    public double Price { get; set; }
    public string PhotoUrl { get; set; }
}
