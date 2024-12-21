﻿namespace TinTanToe.data;

public class PlayerResultInfo
{
    public int playerId { get; set; } 
    public string playerName { get; set; } 
    public PlayerGameStatus status { get; set; }

    public PlayerResultInfo(PlayerResult r, string playerName)
    {
        this.playerId = r.playerId;
        this.status = r.status;
        this.playerName = playerName;
    }
    public override string ToString()
    {
        return $"{nameof(playerName)}:{playerName}, {nameof(playerId)}: {playerId}, {nameof(status)}: {status}";
    }
}