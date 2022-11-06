namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private GameState _state = new();

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _state = _state.AddPointForPlayer1();
            }
            else
            {
                _state = _state.AddPointForPlayer2();
            }
        }

        public string GetScore()
        {
            if (_state.IsDeuce()) return "Deuce";
            if (_state.IsTie()) return ScoreAsString(_state.Player1Points) + "-" + "All";
            if (_state.IsAdvantageOrWin()) return AdvantageOrWinnerAsString();

            return ScoreAsString(_state.Player1Points) + "-" + ScoreAsString(_state.Player2Points);
        }
        
        private string AdvantageOrWinnerAsString() =>
            (_state.Player1Points - _state.Player2Points) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };

        private static string ScoreAsString(int score) =>
            score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
    }

    internal class GameState
    {
        public int Player1Points { get; private init; }

        public int Player2Points { get; private init; }

        public GameState AddPointForPlayer1() =>
            new()
            {
                Player1Points = Player1Points + 1,
                Player2Points = Player2Points
            };

        public GameState AddPointForPlayer2()=>
            new()
            {
                Player1Points = Player1Points,
                Player2Points = Player2Points + 1
            };
        
        public bool IsAdvantageOrWin() => Player1Points >= 4 || Player2Points >= 4;
        
        public bool IsTie() => Player1Points == Player2Points;

        public bool IsDeuce() => Player1Points == Player2Points && Player1Points > 2;
    }
}