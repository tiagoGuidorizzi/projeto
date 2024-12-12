using SharedLibrary.Domain;

public class PlayerRepository : IRepository<Player> {
    private readonly List<Player> _player = new();

    public IEnumerable<Player> GetAll() {
        return _player;
    }

    public void Add(Player player){
        _player.Add(player);
    }
}