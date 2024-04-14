using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
    private readonly Genre[] _genres =
    {
        new()
        {
            Id = 1,
            Name = "Fighting"
        },
        new()
        {
            Id = 2,
            Name = "Action-Adventure"
        },
        new()
        {
            Id = 3,
            Name = "Platformer"
        },
        new()
        {
            Id = 4,
            Name = "Role-Playing"
        },
        new()
        {
            Id = 5,
            Name = "Puzzle"
        }
    };

    public Genre[] GetGenres()
    {
        return _genres;
    }
}