using TinTanToe.data;

namespace TinTanToe.repository;

public class ListGameResultRepository: GameResultRepository
{
    private List<GameResult> _gameResults = new List<GameResult>();

    public List<GameResult> GetAllResults()
    {
        return _gameResults;
    }
    public void CreateGameResult(int gameId, GameResult g)
    {
        g.GameId = gameId ;
        _gameResults.Add(g);
    }

    public GameResult? GetGameResultById(int id)
    {
        foreach (var game in _gameResults)
        {
            if (game.GameId != null && game.GameId == id)
            {
                return game;
            }
        }

        return null;
    }

    public List<GameResult> GetGameResultByPlayerId(int playerId)
    {
        List<GameResult> r = new List<GameResult>();
        foreach (var game in _gameResults)
        {
            if ( game.PlayerResult1 != null && playerId == game.PlayerResult1.PlayerId ||
                 game.PlayerResult2 != null && playerId == game.PlayerResult2.PlayerId)
            {
                r.Add(game);
            }
        }

        return r; 
    }
}