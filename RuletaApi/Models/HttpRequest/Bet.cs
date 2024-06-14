using Microsoft.AspNetCore.Rewrite;
using RuletaApi.Models.HttpResponse;

namespace RuletaApi.Models.HttpRequest
{
    public class Bet
    {
        private RuletaResult result;
        public string BetColor { get; set; } = COLOR.NONE.ToString();
        public int BetNumber { get; set; } = -1;
        public int BetType {  get; set; } = -1;

        public decimal BetAmount { get; set; }
        public decimal BetAmountWin { get; set; }

        public Bet()
        {
        }

        public void setResul(RuletaResult _result) {

            result = _result;
            SetAmount();
        }

        /***
         * 2. La vista debe tener un botón que permita al usuario empezar 
         * Devolver el monto del premio de acuerdo a la apuesta hecha por 
         * el usuario. Siempre 
         * que un usuario no acierte en su apuesta, 
         * perderá el monto apostado. Si el usuario 
         * apuesta a un color dado y acierta, 
         * ganará la mitad del monto de su apuesta. Si el 
         * usuario apuesta a los pares o impares de un color dado y acierta, 
         * ganará un monto  igual a la can�dad apostada. 
         * Si el usuario apuesta a un número y color específicos y 
         * acierta, ganará el triple de la can�dad apostada. 
         */
        private void SetAmount()
        {
            BetAmountWin = 0;
            if (BetColor == result.Color)
            {
                if (BetNumber != -1)
                {
                    if (BetNumber == result.WinNumber)
                        BetAmountWin = BetAmount* 3;
                }
                else if (BetType != -1 && BetType == result.BetTYpe)
                {
                    BetAmountWin = BetAmount;
                }
                else
                    BetAmountWin = BetAmount/2;

            }
        }
    }
}
