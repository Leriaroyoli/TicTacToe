using TinTanToe.data;

namespace TinTanToe.service;

public interface GameService
{
    public int StartGame(int playerId1, int playerId2);

    public void EndGame(int gameId, PlayerResult playerResult1, PlayerResult playerResult2);

    public List<GameResultInfo> GetGameResultByPlayerId(int playerId);
    
    public List<GameResultInfo> GetAllResults();

    public void PlayGame(int gameId, int playerId1, int playerId2);

}