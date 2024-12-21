using TinTanToe.data;

namespace TinTanToe.service;

public interface PlayerService
{
    public void registerPlayer(string? name, string? password);

    public void donate500(int id);

    public int loginPlayer(string? name, string? password);

    public Player? getPlayerById(int id);
    
    public Player? getPlayerByName(string name);

    public List<Player> getAllPlayers();

    public void addOrWithdraw(int playerId,double sum, ManipulationType type);
}
