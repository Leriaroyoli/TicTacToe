using TinTanToe.data;

namespace TinTanToe.repository;

public interface GameRepository
{
    public int CreateGame(Game g);
    public Game? GetGameById(int id);
    public Game? GetGameByPlayerId(int id);
    
}