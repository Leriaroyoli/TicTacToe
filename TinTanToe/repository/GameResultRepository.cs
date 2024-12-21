using TinTanToe.data;

namespace TinTanToe.repository;

public interface GameResultRepository
{
    public void CreateGameResult(int gameId, GameResult g);
    public GameResult? GetGameResultById(int id);
    public List<GameResult> GetGameResultByPlayerId(int id);
    public List<GameResult> GetAllResults();
}