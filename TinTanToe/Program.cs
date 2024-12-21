
using TinTanToe.data;
using TinTanToe.repository;
using TinTanToe.service;

PlayerRepository playerRepository = new ListPlayerRepository();
PlayerService playerService = new DefaultPlayerService(playerRepository);
GameRepository gameRepository = new ListGameRepository();
GameResultRepository gameResultRepository = new ListGameResultRepository();
GameService gameService = new DefaultGameService(playerService, gameRepository, gameResultRepository);

Console.WriteLine("Це гра хрестики-нулики!");

printInstructions();
int r = int.Parse(Console.ReadLine());
switch (r)
{
    case 1 :
        var name = readName();
        var password = readPassword();
        try
        {
            playerService.registerPlayer(name, password);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        break;
    case 2 :
        int playerId1 = login();
        int playerId2 = login();
        int gameId = gameService.startGame(playerId1, playerId2);
        gameService.playGame(gameId, playerId1, playerId2);
        break;
    case 3 :
        printHistory();
        break;
    case 4 :
        printRatings();
        break;
    default:
        Console.WriteLine("Хибний номер!");
        break;
}

string? readPassword()
{
    Console.WriteLine("Введіть пароль:");
    string? password1 = Console.ReadLine();
    return password1;
}

string? readName()
{
    Console.WriteLine("Введіть ім'я:");
    string? s = Console.ReadLine();
    return s;
}

void printInstructions()
{
    Console.WriteLine("щоб зареєструватись введіть 1 \n" +
                      "якщо ви вже зареєстровані, щоб почати введіть 2\n" +
                      "щоб переглянути історію ігор введіть 3\n" +
                      "щоб перевірити рейтинг гравців введіть 4");
}

int login()
{
    var name = readName();
    var password = readPassword();
    try
    {
        return playerService.loginPlayer(name, password);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
    
}

void printRatings()
{
    Console.WriteLine("Щоб вивести рейтинг гравця введіть 1\n" +
                      "Щоб вивести рейтинг усіх гравцій введіть 2");
    int num = int.Parse(Console.ReadLine());
    switch (num)
    {
        case 1:
            Player player = getPlayerFromConsoleByName();
            Console.WriteLine($"Рейтинг гравця: {player.Rating}");
            break;
        
        case 2:
            List<Player> players = playerService.getAllPlayers();
            foreach (var p in players)
            {
                Console.WriteLine($"Рейтинг {p.Name}: {p.Rating}");
            }
            break;
        
        default:
            Console.WriteLine("Вихід з виведення рейтингу");
            break;
        
    }
}

void printHistory()
{
    Console.WriteLine("Щоб вивести інформацію про гравця введіть 1\n" +
                      "Щоб вивести інформацію про всіх гравців введіть 2\n" +
                      "Щоб вийти датисніть будь який символ (крім 1, 2) ");
    int num = int.Parse(Console.ReadLine());
    switch (num)
    {
        case 1:
            var player = getPlayerFromConsoleByName();

            List<GameResult> playerGameResults = gameService.getGameResultByPlayerId(player.Id);
            printGameResults(playerGameResults);
            break;

        case 2:
            List<GameResult> allResults = gameService.GetAllResults();
            printGameResults(allResults);
            break;

        default:
            Console.WriteLine("Вихід з виведення історії");
            break;
    }
}

Player getPlayerFromConsoleByName()
{
    var name = readName();
    Player? player1 = playerService.getPlayerByName(name);
    if (player1 == null)
    {
        var msg = "Гравця не існує";
        Console.WriteLine(msg);
        throw new Exception(msg);
    }

    return player1;
}

void printGameResults(List<GameResult> playerGameResults)
{
    foreach (var g in playerGameResults)
    {
        Console.WriteLine(g);
    }
}
