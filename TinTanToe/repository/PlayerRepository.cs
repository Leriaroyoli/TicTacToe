using TinTanToe.data;

namespace TinTanToe.repository;

public interface PlayerRepository
{
    public void AddPlayer(Player p);
    public Player? GetPlayerById(int id);
    public Player? GetPlayerByName(string name);
    public List<Player> GetAllPlayers();

}