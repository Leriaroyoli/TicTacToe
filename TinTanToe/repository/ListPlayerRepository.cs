using TinTanToe.data;

namespace TinTanToe.repository;

public class ListPlayerRepository : PlayerRepository
{
    private List<Player> _players = new List<Player>();
    
    public void AddPlayer(Player p)
    {
        int nextId = _players.Count; 
        p.Id = nextId;
        _players.Add(p);
    }

    public Player? GetPlayerById(int id)
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
    

    public Player? GetPlayerByName(string name)
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

    public List<Player> GetAllPlayers()
    {
        return _players;
    }
}