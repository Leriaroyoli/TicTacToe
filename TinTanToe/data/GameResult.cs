namespace TinTanToe.data;

public class GameResult
{
    public int GameId { get; set; }
    public PlayerResult? PlayerResult1 { get; set; }
    public PlayerResult? PlayerResult2 { get; set; }

    public GameResult(int gameId, PlayerResult? playerResult1, PlayerResult? playerResult2)
    {
        this.GameId = gameId;
        this.PlayerResult1 = playerResult1;
        this.PlayerResult2 = playerResult2;
    }
    
    public override string ToString()
    {
        return $"{nameof(GameId)}: {GameId},\n{nameof(PlayerResult1)}: {PlayerResult1}," +
               $"\n{nameof(PlayerResult2)}: {PlayerResult2}";
    }
}