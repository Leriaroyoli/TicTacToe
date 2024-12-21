namespace TinTanToe.data;

public class PlayerResult
{
    public int playerId { get; set; } 
    public string status { get; set; }
    public override string ToString()
    {
        return $"{nameof(playerId)}: {playerId}, {nameof(status)}: {status}";
    }
}