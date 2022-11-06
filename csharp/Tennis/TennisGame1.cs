namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly GameState _state = new();

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _state.AddPointForPlayer1();
            }
            else
            {
                _state.AddPointForPlayer2();
            }
        }

        public string GetScore()
        {
            if (IsDeuce()) return "Deuce";
            if (IsTie()) return ScoreAsString(_state.Player1Points) + "-" + "All";
            if (IsAdvantageOrWin()) return AdvantageOrWinnerAsString();

            return ScoreAsString(_state.Player1Points) + "-" + ScoreAsString(_state.Player2Points);
        }

        private bool IsAdvantageOrWin() => _state.Player1Points >= 4 || _state.Player2Points >= 4;

        private bool IsTie() => _state.Player1Points == _state.Player2Points;

        private bool IsDeuce() => _state.Player1Points == _state.Player2Points && _state.Player1Points > 2;

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
        public int Player1Points { get; private set; }

        public int Player2Points { get; private set; }

        public void AddPointForPlayer1()
        {
            Player1Points++;
        }

        public void AddPointForPlayer2()
        {
            Player2Points++;
        }
    }
}