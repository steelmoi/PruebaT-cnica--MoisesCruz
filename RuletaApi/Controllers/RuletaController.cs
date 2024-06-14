using Microsoft.AspNetCore.Mvc;
using RuletaApi.Models;
using RuletaApi.Models.HttpRequest;
using RuletaApi.Models.HttpResponse;

namespace RuletaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuletaController : Controller
    {
        [HttpGet("GetBet")]
        public RuletaResult GetBet()
        {
            RuletaResult result = new RuletaResult();
            result.StartGame();
            return result;
        }

        [HttpPost("GetAmountWin")]
        public decimal GetAmountWin([FromBody] RequestBet request)
        {
            try
            {
                request.Bet.setResul(request.Result);
                return request.Bet.BetAmountWin;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
