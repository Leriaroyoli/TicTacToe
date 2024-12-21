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

        toScorePoints(playerResult1);
        toScorePoints(playerResult2);

        GameResult gr = new GameResult(gameId, playerResult1, playerResult2);
        _gameResultRepository.CreateGameResult(gameId, gr);
    }

    public List<GameResultInfo> getGameResultByPlayerId(int playerId)
    {
        List<GameResult> gameResults = _gameResultRepository.GetGameResultByPlayerId(playerId);
        var gameResultsInfo = getGameResultsInfo(gameResults);

        return gameResultsInfo;
    }
    
    public List<GameResultInfo> GetAllResults()
    {
        List<GameResult> allResults = _gameResultRepository.GetAllResults();
        return getGameResultsInfo(allResults);
    }
    
    public void playGame(int gameId, int playerId1, int playerId2)
    {
        char[,] board = new char[3, 3];
        InitializeBoard(board);
        int currentPlayer = playerId1;
        bool gameEnded = false;

        while (!gameEnded)
        {
            PrintBoard(board);
            Console.WriteLine($"Player {currentPlayer}, enter your move (row and column): ");
            string[] input = Console.ReadLine().Split(' ');
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            if (board[row, col] == ' ')
            {
                board[row, col] = currentPlayer == playerId1 ? 'X' : 'O';

                if (CheckWinner(board, currentPlayer == playerId1 ? 'X' : 'O'))
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    endGame(gameId, 
                        new PlayerResult(playerId1, currentPlayer == playerId1 ? PlayerGameStatus.WIN: PlayerGameStatus.LOSE),
                        new PlayerResult(playerId2, currentPlayer == playerId2 ? PlayerGameStatus.WIN: PlayerGameStatus.LOSE));
                    gameEnded = true;
                }
                else if (IsBoardFull(board))
                {
                    Console.WriteLine("The game is a draw!");
                    endGame(gameId, 
                        new PlayerResult(playerId1, PlayerGameStatus.DRAW),
                        new PlayerResult(playerId2, PlayerGameStatus.DRAW));
                    gameEnded = true;
                }
                else
                {
                    currentPlayer = currentPlayer == playerId1 ? playerId2 : playerId1;
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }

    private void InitializeBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    private void PrintBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] == ' ' ? '.' : board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("-----");
        }
    }

    private bool CheckWinner(char[,] board, char symbol)
    {
        for (int i = 0; i < 3; i++)
        {
            // Check rows and columns
            if ((board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol) ||
                (board[0, i] == symbol && board[1, i] == symbol && board[2, i] == symbol))
            {
                return true;
            }
        }
        // Check diagonals
        return (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol) ||
               (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol);
    }

    private bool IsBoardFull(char[,] board)
    {
        foreach (var cell in board)
        {
            if (cell == ' ') return false;
        }
        return true;
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
    
    private List<GameResultInfo> getGameResultsInfo(List<GameResult> gameResults)
    {
        List<GameResultInfo> gameResultsInfo = new List<GameResultInfo>();
        foreach (var g in gameResults)
        {
            PlayerResultInfo p1 = buildPlayerResultInfo(g.playerResult1);
            PlayerResultInfo p2 = buildPlayerResultInfo(g.playerResult2);
            GameResultInfo gri = new GameResultInfo(g.gameId, p1, p2);
            gameResultsInfo.Add(gri);
        }

        return gameResultsInfo;
    }

    private PlayerResultInfo buildPlayerResultInfo(PlayerResult playerResult)
    {
        int playerId1 = playerResult.playerId;
        Player? player1 =_playerService.getPlayerById(playerId1);
        return new PlayerResultInfo(playerResult, player1.Name);
    }
    
    private void toScorePoints(PlayerResult playerResult1)
    {
        switch (playerResult1.status)
        {
            case PlayerGameStatus.WIN:
                _playerService.addOrWithdraw(playerResult1.playerId, 100, ManipulationType.ADD);
                break;
            case PlayerGameStatus.LOSE:
                _playerService.addOrWithdraw(playerResult1.playerId, 100, ManipulationType.WITHDRAW);
                break;
            case PlayerGameStatus.DRAW:
                _playerService.addOrWithdraw(playerResult1.playerId, 50, ManipulationType.ADD);
                break;
        }
    }

}