
using TinTanToe.data;
using TinTanToe.repository;
using TinTanToe.service;

Console.OutputEncoding = System.Text.Encoding.UTF8;

PlayerRepository playerRepository = new ListPlayerRepository();
PlayerService playerService = new DefaultPlayerService(playerRepository);
GameRepository gameRepository = new ListGameRepository();
GameResultRepository gameResultRepository = new ListGameResultRepository();
GameService gameService = new DefaultGameService(playerService, gameRepository, gameResultRepository);

Console.WriteLine("Це гра хрестики-нулики!");

while (true)
{
    try
    {
        PrintInstructions();
        if (!int.TryParse(Console.ReadLine(), out int r))
        {
            Console.WriteLine("Неправильний ввід. Будь ласка, введіть номер.");
            continue;
        }

        switch (r)
        {
            case 1:
                var name = ReadName();
                var password = ReadPassword();
                try
                {
                    playerService.RegisterPlayer(name, password);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case 2:
                int playerId1 = Login();
                int playerId2 = Login();
                int gameId = gameService.StartGame(playerId1, playerId2);
                
                // Play Tic-Tac-Toe game
                gameService.PlayGame(gameId, playerId1, playerId2);
                break;
            case 3:
                PrintHistory();
                break;
            case 4:
                PrintRatings();
                break;
            case 0:
                Console.WriteLine("Вихід з гри. До побачення!");
                return;
            default:
                Console.WriteLine("Хибний номер!");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Сталася помилка: {ex.Message}");
    }
}

string? ReadPassword()
{
    Console.WriteLine("Введіть пароль:");
    string? password1 = Console.ReadLine();
    return password1;
}

string? ReadName()
{
    Console.WriteLine("Введіть ім'я:");
    string? s = Console.ReadLine();
    return s;
}

void PrintInstructions()
{
    Console.WriteLine("щоб зареєструватись введіть 1 \n" +
                      "якщо ви вже зареєстровані, щоб почати введіть 2\n" +
                      "щоб переглянути історію ігор введіть 3\n" +
                      "щоб перевірити рейтинг гравців введіть 4");
}

int Login()
{
    var name = ReadName();
    var password = ReadPassword();
    try
    {
        return playerService.LoginPlayer(name, password);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
    
}

void PrintRatings()
{
    Console.WriteLine("Щоб вивести рейтинг гравця введіть 1\n" +
                      "Щоб вивести рейтинг усіх гравцій введіть 2");
    int num = int.Parse(Console.ReadLine());
    switch (num)
    {
        case 1:
            Player player = GetPlayerFromConsoleByName();
            Console.WriteLine($"Рейтинг гравця: {player.Rating}");
            break;
        
        case 2:
            List<Player> players = playerService.GetAllPlayers();
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

void PrintHistory()
{
    Console.WriteLine("Щоб вивести інформацію про гравця введіть 1\n" +
                      "Щоб вивести інформацію про всіх гравців введіть 2\n" +
                      "Щоб вийти датисніть будь який символ (крім 1, 2) ");
    int num = int.Parse(Console.ReadLine());
    switch (num)
    {
        case 1:
            var player = GetPlayerFromConsoleByName();

            List<GameResultInfo> playerGameResults = gameService.GetGameResultByPlayerId(player.Id);
            PrintGameResults(playerGameResults);
            break;

        case 2:
            List<GameResultInfo> allResults = gameService.GetAllResults();
            PrintGameResults(allResults);
            break;

        default:
            Console.WriteLine("Вихід з виведення історії");
            break;
    }
}

Player GetPlayerFromConsoleByName()
{
    var name = ReadName();
    Player? player1 = playerService.GetPlayerByName(name);
    if (player1 == null)
    {
        var msg = "Гравця не існує";
        Console.WriteLine(msg);
        throw new Exception(msg);
    }

    return player1;
}

void PrintGameResults(List<GameResultInfo> playerGameResults)
{
    foreach (var g in playerGameResults)
    {
        Console.WriteLine(g);
    }
}
