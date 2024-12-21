using TinTanToe.data;

namespace TinTanToe.repository;

public interface PlayerRepository
{
    public void addPlayer(Player p);
    public Player? getPlayerById(int id);
    public Player? getPlayerByName(string name);
    public List<Player> getAllPlayers();

}