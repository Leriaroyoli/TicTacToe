namespace TinTanToe.data;

public class PlayerResultInfo
{
    public int PlayerId { get; set; } 
    public string PlayerName { get; set; } 
    public PlayerGameStatus Status { get; set; }

    public PlayerResultInfo(PlayerResult r, string playerName)
    {
        this.PlayerId = r.PlayerId;
        this.Status = r.Status;
        this.PlayerName = playerName;
    }
    public override string ToString()
    {
        return $"{nameof(PlayerName)}:{PlayerName}, {nameof(PlayerId)}: {PlayerId}, {nameof(Status)}: {Status}";
    }
}