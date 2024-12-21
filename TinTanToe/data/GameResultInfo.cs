namespace TinTanToe.data;

public class GameResultInfo
{
    public int gameId { get; set; }
    public PlayerResultInfo playerResult1 { get; set; }
    public PlayerResultInfo playerResult2 { get; set; }

    public GameResultInfo(int gameId, PlayerResultInfo playerResult1, PlayerResultInfo playerResult2)
    {
        this.gameId = gameId;
        this.playerResult1 = playerResult1;
        this.playerResult2 = playerResult2;
    }
    
    public override string ToString()
    {
        return $"{nameof(gameId)}: {gameId},\n{nameof(playerResult1)}: {playerResult1}," +
               $"\n{nameof(playerResult2)}: {playerResult2}";
    }
}