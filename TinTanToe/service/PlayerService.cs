using TinTanToe.data;

namespace TinTanToe.service;

public interface PlayerService
{
    public void RegisterPlayer(string? name, string? password);

    public void Donate500(int id);

    public int LoginPlayer(string? name, string? password);

    public Player? GetPlayerById(int id);
    
    public Player? GetPlayerByName(string name);

    public List<Player> GetAllPlayers();

    public void AddOrWithdraw(int playerId,double sum, ManipulationType type);
}
