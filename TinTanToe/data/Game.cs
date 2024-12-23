namespace TinTanToe.data;

public class Game
{
    public int? Id { get; set; }
    public int PlayerId1 { get; set; }
    public int PlayerId2 { get; set; }

    public Game(int playerId1, int playerId2)
    {
        this.PlayerId1 = playerId1;
        this.PlayerId2 = playerId2;
    }
}