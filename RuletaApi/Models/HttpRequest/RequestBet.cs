using RuletaApi.Models.HttpResponse;

namespace RuletaApi.Models.HttpRequest
{
    public class RequestBet
    {
        public Bet Bet { get; set; }
        public RuletaResult Result { get; set; }

        public RequestBet() { 

        }
    }
}
