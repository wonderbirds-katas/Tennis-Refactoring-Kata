namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private IGameState _state = new GameState();

        public void WonPoint(string playerName) =>
            _state = playerName switch
            {
                "player1" => _state.AddPointForPlayer1(),
                _ => _state.AddPointForPlayer2()
            };

        public string GetScore() => _state.AsString();
    }

    internal interface IGameState
    {
        IGameState AddPointForPlayer1();
        IGameState AddPointForPlayer2();
        string AsString();
    }

    internal class GameState : IGameState
    {
        private readonly int _player1Points;

        private readonly int _player2Points;

        public GameState()
        {
        }
        
        public GameState(int player1Points, int player2Points)
        {
            _player1Points = player1Points;
            _player2Points = player2Points;
        }

        public IGameState AddPointForPlayer1() => new GameState(_player1Points + 1, _player2Points);

        public IGameState AddPointForPlayer2() => new GameState(_player1Points, _player2Points + 1);

        public string AsString()
        {
            if (IsDeuce()) return "Deuce";
            if (IsTie()) return ScoreAsString(_player1Points) + "-" + "All";
            if (IsAdvantageOrWin()) return AdvantageOrWinnerAsString();

            return ScoreAsString(_player1Points) + "-" + ScoreAsString(_player2Points);
        }

        private bool IsAdvantageOrWin() => _player1Points >= 4 || _player2Points >= 4;

        private bool IsTie() => _player1Points == _player2Points;

        private bool IsDeuce() => _player1Points == _player2Points && _player1Points > 2;

        private string AdvantageOrWinnerAsString() =>
            (_player1Points - _player2Points) switch
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
}