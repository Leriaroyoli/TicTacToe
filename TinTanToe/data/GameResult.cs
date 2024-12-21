namespace TinTanToe.data;

public class GameResult
{
    public int? gameId { get; set; }
    public PlayerResult? playerResult1 { get; set; }
    public PlayerResult? playerResult2 { get; set; }

    public GameResult(int? gameId, PlayerResult? playerResult1, PlayerResult? playerResult2)
    {
        this.gameId = gameId;
        this.playerResult1 = playerResult1;
        this.playerResult2 = playerResult2;
    }

    // public override string ToString()
    // {
    //     return 
    // } 
    public override string ToString()
    {
        return $"{nameof(gameId)}: {gameId},\n{nameof(playerResult1)}: {playerResult1}," +
               $"\n{nameof(playerResult2)}: {playerResult2}";
    }
}