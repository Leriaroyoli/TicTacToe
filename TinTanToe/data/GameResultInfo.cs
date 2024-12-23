namespace TinTanToe.data;

public class GameResultInfo
{
    public int GameId { get; set; }
    public PlayerResultInfo PlayerResult1 { get; set; }
    public PlayerResultInfo PlayerResult2 { get; set; }

    public GameResultInfo(int gameId, PlayerResultInfo playerResult1, PlayerResultInfo playerResult2)
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