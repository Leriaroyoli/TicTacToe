using TinTanToe.data;

namespace TinTanToe.repository;

public class ListPlayerRepository : PlayerRepository
{
    private List<Player> _players = new List<Player>();
    
    public void addPlayer(Player p)
    {
        int nextId = _players.Count; 
        p.Id = nextId;
        _players.Add(p);
    }

    public Player? getPlayerById(int id)
    {
        foreach (var player in _players)
        {
            if (player.Id != null && player.Id == id)
            {
                return player;
            }
        }

        return null;
    }   
    

    public Player? getPlayerByName(string name)
    {
        foreach (var player in _players)
        {
            if (player.Name != null && player.Name == name)
            {
                return player;
            }
        }

        return null;
    }

    public List<Player> getAllPlayers()
    {
        return _players;
    }
}