using TinTanToe.data;

namespace TinTanToe.repository;

public class ListGameResultRepository: GameResultRepository
{
    private List<GameResult> _gameResults = new List<GameResult>();
    
    public void CreateGameResult(int gameId, GameResult g)
    {
        g.gameId = gameId ;
        _gameResults.Add(g);
    }

    public GameResult? GetGameResultById(int id)
    {
        foreach (var game in _gameResults)
        {
            if (game.gameId != null && game.gameId == id)
            {
                return game;
            }
        }

        return null;
    }

    public GameResult? GetGameResultByPlayerId(int playerId)
    {
        foreach (var game in _gameResults)
        {
            if ( game.playerResult1 != null && playerId == game.playerResult1.playerId ||
                 game.playerResult2 != null && playerId == game.playerResult2.playerId)
            {
                return game;
            }
        }

        return null; 
    }
}