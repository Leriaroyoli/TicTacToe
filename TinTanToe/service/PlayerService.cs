using TinTanToe.data;

namespace TinTanToe.service;

public interface PlayerService
{
    public void registerPlayer(string name, string password);

    public void donate500(int id);

    public int? loginPlayer(string name, string password);

    public double getRating(string name);

    public Player? getPlayerById(int id);
    
    public Player? getPlayerByName(string name);

}
