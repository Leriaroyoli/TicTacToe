using TinTanToe.data;

namespace TinTanToe.service;

public interface GameService
{
    public int startGame(int playerId1, int playerId2);

    public void endGame(int gameId, PlayerResult playerResult1, PlayerResult playerResult2);

    public List<GameResultInfo> getGameResultByPlayerId(int playerId);
    
    public List<GameResultInfo> GetAllResults();

    public void playGame(int gameId, int playerId1, int playerId2);

}