using TinTanToe.data;

namespace TinTanToe.service;

public interface GameService
{
    public int startGame(int playerId1, int playerId2);

    public void endGame(int gameId, PlayerResult playerResult1, PlayerResult playerResult2);

    public List<GameResult> getGameResultByPlayerId(int playerId);
    
    public List<GameResult> GetAllResults();

    public void playGame(int gameId, int playerId1, int playerId2);

}