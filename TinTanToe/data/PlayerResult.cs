namespace TinTanToe.data;

public class PlayerResult
{
    public int playerId { get; set; } 
    public PlayerGameStatus status { get; set; }

    public PlayerResult(int playerId, PlayerGameStatus status)
    {
        this.status = status;
        this.playerId = playerId;
    }
    
    public override string ToString()
    {
        return $"{nameof(playerId)}: {playerId}, {nameof(status)}: {status}";
    }
}