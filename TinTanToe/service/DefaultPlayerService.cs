using TinTanToe.data;
using TinTanToe.repository;

namespace TinTanToe.service;

public class DefaultPlayerService : PlayerService 
{
    private PlayerRepository _playerRepository;
    
    public DefaultPlayerService(PlayerRepository playerRepository)
    {
        _playerRepository = playerRepository; 
    }
    
    public void registerPlayer(string name, string password)
    {//todo 1. перевірити чи не існує гравця з таким ім'ям 
        // 2. якщо існує, помилка. 3.створити об'єкт player 4. зберегти в _playerRepository 
        var existingPlayer = GetPlayerByNameAndThrowIfNull(name, "Гравець з таким їм'ям вже існує");

        Player player = new Player(name, password, 1000);
        
        _playerRepository.addPlayer(player);
    }

   

    public void donate500(int id)
    {
        Player? p = getPlayerById(id);
        if (p == null)
        {
            throw new Exception("Гравця з таким id не існує");
        }
        p.addToRating(500);
    }

    public int? loginPlayer(string name, string password)
    {
        Player? existingPlayer = GetPlayerByNameAndThrowIfNull(name, "Гравця не існує");

        if (existingPlayer.Password == password)
        {
            return existingPlayer.Id;
        }

        throw new Exception("Пароль не вірний");
    }

    public double getRating(string name)
    {
        Player? player = GetPlayerByNameAndThrowIfNull(name, "Гравця не знайдено");

        return player.Rating; 
    }

    public Player? getPlayerById(int id)
    {
        return _playerRepository.getPlayerById(id);
    }
    
    public Player? getPlayerByName(string name)
    {
        return _playerRepository.getPlayerByName(name);
    }
    
    private Player? GetPlayerByNameAndThrowIfNull(string name, string exceptionMessage)
    {
        Player? existingPlayer = getPlayerByName(name);
        if (existingPlayer == null)
        {
            throw new Exception(exceptionMessage);
        }

        return existingPlayer;
    }
}