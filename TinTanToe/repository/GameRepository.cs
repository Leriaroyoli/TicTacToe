using TinTanToe.data;

namespace TinTanToe.repository;

public interface GameRepository
{
    public int createGame(Game g);
    public Game? getGameById(int id);
    public Game? getGameByPlayerId(int id);
    
}