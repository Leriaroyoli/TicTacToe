namespace TinTanToe.data;

public class Game
{
    public int? id { get; set; }
    public int playerId1 { get; set; }
    public int playerId2 { get; set; }

    public Game(int playerId1, int playerId2)
    {
        this.playerId1 = playerId1;
        this.playerId2 = playerId2;
    }
}