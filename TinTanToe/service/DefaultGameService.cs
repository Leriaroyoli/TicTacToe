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
        Player? player1 = GetAndValidatePlayer(playerId1);
        Player? player2 = GetAndValidatePlayer(playerId2);

        Game g = new Game(playerId1, playerId2);
        return _gameRepository.createGame(g);
    }

    
    public void endGame(int gameId, PlayerResult playerResult1, PlayerResult playerResult2)
    {
        
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