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
    
    public void RegisterPlayer(string? name, string? password)
    {//todo 1. перевірити чи не існує гравця з таким ім'ям 
        // 2. якщо існує, помилка. 3.створити об'єкт player 4. зберегти в _playerRepository 
        ValidateNameAndPassword(name, password);
        ValidatePlayerNotFound(name, "Гравець з таким їм'ям вже існує");

        Player player = new Player(name, password, 1000);
        
        _playerRepository.AddPlayer(player);
    }
    
    public void Donate500(int id)
    {
        var p = GetPlayerByIdOrThrowIfNull(id);
        p.AddToRating(500);
    }
    
    public int LoginPlayer(string? name, string? password)
    {
        ValidateNameAndPassword(name, password);
        Player existingPlayer = GetPlayerByNameAndThrowIfNull(name, "Гравця не існує");

        if (existingPlayer.Password == password)
        {
            return existingPlayer.Id;
        }

        throw new Exception("Пароль не вірний");
    }
    
    public Player? GetPlayerById(int id)
    {
        return _playerRepository.GetPlayerById(id);
    }
    
    public Player? GetPlayerByName(string name)
    {
        return _playerRepository.GetPlayerByName(name);
    }

    public List<Player> GetAllPlayers()
    {
        return _playerRepository.GetAllPlayers()
            .OrderByDescending(item => item.Rating)
            .ToList();
    }

    public void AddOrWithdraw(int playerId, double sum, ManipulationType type)
    {
        Player player = GetPlayerByIdOrThrowIfNull(playerId);
        switch (type)
        {
            case ManipulationType.ADD:
                player.AddToRating(sum);
                break;
            case ManipulationType.WITHDRAW:
                player.WithdrawFromRating(sum);
                break;
        }
    }
    
    private void ValidatePlayerNotFound(string name, string exceptionMessage)
    {
        Player? existingPlayer = GetPlayerByName(name);
        if (existingPlayer != null)
        {
            throw new Exception(exceptionMessage);
        }
    } 
    private Player GetPlayerByNameAndThrowIfNull(string name, string exceptionMessage)
    {
        Player? existingPlayer = GetPlayerByName(name);
        if (existingPlayer == null)
        {
            throw new Exception(exceptionMessage);
        }

        return existingPlayer;
        
    } 
    private void ValidateNameAndPassword(string? name, string? password)
    {
        if (name== null || password== null)
        {
            throw new Exception("Ім'я або пароль не вказано!");
        }
    }
    
    private Player GetPlayerByIdOrThrowIfNull(int id)
    {
        Player? p = GetPlayerById(id);
        if (p == null)
        {
            throw new Exception("Гравця з таким id не існує");
        }

        return p;
    }
}