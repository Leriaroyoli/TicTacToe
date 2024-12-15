using TinTanToe.data;

namespace TinTanToe.repository;

public class ListGameRepository : GameRepository
{
    private List<Game> _games = new List<Game>();

    public int createGame(Game g)
    {
        int nextId = _games.Count;
        g.id = nextId;
        _games.Add(g);
        return nextId;
    } 

    public Game? getGameById(int id)
    {
        foreach (var game in _games)
        {
            if (game.id != null && game.id == id)
            {
                return game;
            }
        }

        return null;
    }

    public Game? getGameByPlayerId(int id)
    {
        foreach (var game in _games)
        {
            if (id == game.playerId1 || id == game.playerId2)
            {
                return game;
            }
        }

        return null; 
    }
}