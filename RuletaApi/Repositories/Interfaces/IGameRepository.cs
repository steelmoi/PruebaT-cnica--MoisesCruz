using RuletaApi.Models;

namespace RuletaApi.Repositories.Interfaces
{
    public interface IGameRepository
    {
        bool Update(Game game);
        bool Add(Game game);
        Game GetGameByUser(string UserName);
    }
}
