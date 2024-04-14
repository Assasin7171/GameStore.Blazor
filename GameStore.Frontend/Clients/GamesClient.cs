using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> _games =
    [
        new GameSummary
        {
            Id = 1,
            Name = "Streat Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            RelaseDate = new DateOnly(2010, 2, 10)
        },

        new GameSummary
        {
            Id = 2,
            Name = "The Legend of Zelda: Ocarina of Time",
            Genre = "Action-Adventure",
            Price = 29.99M,
            RelaseDate = new DateOnly(1998, 11, 21)
        },
        new GameSummary
        {
            Id = 3,
            Name = "Super Mario Bros.",
            Genre = "Platformer",
            Price = 9.99M,
            RelaseDate = new DateOnly(1985, 9, 13)
        },
        new GameSummary
        {
            Id = 4,
            Name = "Final Fantasy VII",
            Genre = "Role-Playing",
            Price = 39.99M,
            RelaseDate = new DateOnly(1997, 1, 31)
        },
        new GameSummary
        {
            Id = 5,
            Name = "Tetris",
            Genre = "Puzzle",
            Price = 4.99M,
            RelaseDate = new DateOnly(1984, 6, 6)
        }
    ];

    private readonly Genre[] _genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames()
    {
        return [.._games];
    }

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = _genres.Single(_genres => _genres.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = _games.Count + 1,
            Name = game.Name,
            Genre = game.GenreId,
            Price = game.Price,
            RelaseDate = game.ReleaseDate
        };
        _games.Add(gameSummary);
    }

    public GameDetails GetGame(int id)
    {
        var game = _games.Find(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(game);

        var genre = _genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.RelaseDate
        };
    }
}