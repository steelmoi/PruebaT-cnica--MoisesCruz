using RuletaApi.Models;
using RuletaApi.Repositories.Interfaces;

namespace RuletaApi.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _DBContext;
        public GameRepository(GameContext DBContext)
        {
            _DBContext = DBContext;
        }
        public bool Add(Game game)
        {
            _DBContext.Games.Add(game);
            _DBContext.SaveChanges();

            return true;
        }

        public Game GetGameByUser(string UserName)
        {
            return _DBContext.Games.Where(G => G.UserName == UserName).FirstOrDefault();
        }

        public bool Update(Game game)
        {
            _DBContext.Games.Update(game);
            _DBContext.SaveChanges();

            return true;
        }
    }
}
