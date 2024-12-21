using TinTanToe.data;
using TinTanToe.repository;

namespace TinTanToe.service;

public class DefaultGameService : GameService
{
    private PlayerService _playerService;
    private GameRepository _gameRepository;
    private GameResultRepository _gameResultRepository;

    public DefaultGameService(PlayerService playerService, GameRepository gameRepository,
        GameResultRepository gameResultRepository)
    {
        _playerService = playerService;
        _gameRepository = gameRepository;
        _gameResultRepository = gameResultRepository; 
    }
        
    public int startGame(int playerId1, int playerId2)
    {
        GetAndValidatePlayer(playerId1);
        GetAndValidatePlayer(playerId2);

        Game g = new Game(playerId1, playerId2);
        return _gameRepository.createGame(g);
    }
    
    public void endGame(int gameId, PlayerResult playerResult1, PlayerResult playerResult2)
    {
        Game? game =_gameRepository.getGameById(gameId);
        if (game == null)
        {
            throw new Exception("Гра не знайдена:(");
        }

        GameResult gr = new GameResult(gameId, playerResult1, playerResult2);
        _gameResultRepository.CreateGameResult(gameId, gr);
    }

    public List<GameResult> getGameResultByPlayerId(int playerId)
    {
       return _gameResultRepository.GetGameResultByPlayerId(playerId);
    }
    
    public List<GameResult> GetAllResults()
    {
        List<GameResult> allResults = _gameResultRepository.GetAllResults();
        return allResults;
    }
    
    private Player? GetAndValidatePlayer(int playerId1)
    { 
        Player? player1 = _playerService.getPlayerById(playerId1); 
        validatePlayer(player1);
        return player1;
    }
    
    private void validatePlayer(Player? player)
    {
        if (player == null || player.Rating < 100)
        {
            throw new Exception("Гравець не може прийняти участь ");
        }
    }

}