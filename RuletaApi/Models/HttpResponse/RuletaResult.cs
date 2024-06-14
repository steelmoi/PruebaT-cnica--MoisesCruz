namespace RuletaApi.Models.HttpResponse
{
    public class RuletaResult
    {
        public void StartGame()
        {
            _WinNumber = new Random().Next(0, 37);
            _ColorGame = new Random().Next(1, 3);

            Color = SetColorName();
        }

        private string SetColorName()
        {
            switch (_ColorGame)
            {
                case (int)COLOR.BLACK:
                    return COLOR.BLACK.ToString();
                case (int)COLOR.RED:
                    return  COLOR.RED.ToString();
                default:
                    return COLOR.NONE.ToString();
            }
        }

        private int _WinNumber;
        public int WinNumber { 
            get { return _WinNumber; } 
            set { _WinNumber = value; }
        }
        public int BetTYpe
        {
            get
            {
                if (_WinNumber % 2 == 0)
                    return (int)TYPE_NUMBER.EVEN;
                else
                    return (int)TYPE_NUMBER.ODD;
            }
            set {; }
        }

        private int _ColorGame;

        private string _Color;
        public string Color
        {
            get
            {
                return _Color;
            }
            set { _Color = value; }
        }
    }
}
