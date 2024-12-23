using TinTanToe.data;

namespace TinTanToe.repository;

public class ListGameRepository : GameRepository
{
    private List<Game> _games = new List<Game>();

    public int CreateGame(Game g)
    {
        int nextId = _games.Count;
        g.Id = nextId;
        _games.Add(g);
        return nextId;
    } 

    public Game? GetGameById(int id)
    {
        foreach (var game in _games)
        {
            if (game.Id != null && game.Id == id)
            {
                return game;
            }
        }

        return null;
    }

    public Game? GetGameByPlayerId(int id)
    {
        foreach (var game in _games)
        {
            if (id == game.PlayerId1 || id == game.PlayerId2)
            {
                return game;
            }
        }

        return null; 
    }
}