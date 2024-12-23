namespace TinTanToe.data;

public class PlayerResult
{
    public int PlayerId { get; set; } 
    public PlayerGameStatus Status { get; set; }

    public PlayerResult(int playerId, PlayerGameStatus status)
    {
        this.Status = status;
        this.PlayerId = playerId;
    }
    
    public override string ToString()
    {
        return $"{nameof(PlayerId)}: {PlayerId}, {nameof(Status)}: {Status}";
    }
}