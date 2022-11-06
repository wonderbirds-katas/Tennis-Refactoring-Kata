namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private IGameState _state = new Tie(0);

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

    internal class Tie : IGameState
    {
        private readonly int _points;

        public Tie(int points) => _points = points;

        public IGameState AddPointForPlayer1() => new GameState(_points + 1, _points);

        public IGameState AddPointForPlayer2() => new GameState(_points, _points + 1);

        public string AsString() => _points.AsString() + "-" + "All";
    }

    internal class GameState : IGameState
    {
        private readonly int _player1Points;

        private readonly int _player2Points;

        public GameState(int player1Points, int player2Points)
        {
            _player1Points = player1Points;
            _player2Points = player2Points;
        }

        public IGameState AddPointForPlayer1()
        {
            var nextPlayer1Points = _player1Points + 1;

            if (IsTie(nextPlayer1Points, _player2Points))
            {
                return new Tie(nextPlayer1Points);
            }

            return new GameState(nextPlayer1Points, _player2Points);
        }

        public IGameState AddPointForPlayer2()
        {
            var nextPlayer2Points = _player2Points + 1;

            if (IsTie(_player1Points, nextPlayer2Points))
            {
                return new Tie(nextPlayer2Points);
            }

            return new GameState(_player1Points, nextPlayer2Points);
        }

        public string AsString()
        {
            if (IsDeuce()) return "Deuce";
            if (IsAdvantageOrWin()) return AdvantageOrWinnerAsString();

            return _player1Points.AsString() + "-" + _player2Points.AsString();
        }

        private bool IsAdvantageOrWin() => _player1Points >= 4 || _player2Points >= 4;

        private bool IsTie(int player1Points, int player2Points) =>
            player1Points == player2Points && _player1Points <= 2;

        private bool IsDeuce() => _player1Points == _player2Points && _player1Points > 2;

        private string AdvantageOrWinnerAsString() =>
            (_player1Points - _player2Points) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
    }

    internal static class ScoreExtensions
    {
        public static string AsString(this int score) =>
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