using TinTanToe.data;

namespace TinTanToe.repository;

public interface GameResultRepository
{
    public void CreateGameResult(int gameId, GameResult g);
    public GameResult? GetGameResultById(int id);
    public GameResult? GetGameResultByPlayerId(int id);
}