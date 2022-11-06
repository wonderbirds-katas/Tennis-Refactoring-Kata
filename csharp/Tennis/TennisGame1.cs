using System;

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

    internal class Deuce : IGameState
    {
        private readonly int _points;

        public Deuce(int points) => _points = points;

        public IGameState AddPointForPlayer1() => new GameState(_points + 1, _points);

        public IGameState AddPointForPlayer2() => new GameState(_points, _points + 1);

        public string AsString() => "Deuce";
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

        public IGameState AddPointForPlayer1() => CreateStateWithPoints(_player1Points + 1, _player2Points);

        public IGameState AddPointForPlayer2() => CreateStateWithPoints(_player1Points, _player2Points + 1);

        private IGameState CreateStateWithPoints(int player1Points, int player2Points)
        {
            if (IsTie(player1Points, player2Points)) return new Tie(player1Points);
            if (IsDeuce(player1Points, player2Points)) return new Deuce(player1Points);

            return new GameState(player1Points, player2Points);
        }

        public string AsString()
        {
            if ((_player1Points >= 4 || _player2Points >= 4) && _player1Points - _player2Points == 1)
                return "Advantage player1";
            if ((_player1Points >= 4 || _player2Points >= 4) && _player2Points - _player1Points == 1)
                return "Advantage player2";
            if ((_player1Points >= 4 || _player2Points >= 4) && _player1Points - _player2Points >= 2)
                return "Win for player1";
            if ((_player1Points >= 4 || _player2Points >= 4) && _player2Points - _player1Points >= 2)
                return "Win for player2";

            return _player1Points.AsString() + "-" + _player2Points.AsString();
        }

        private bool IsTie(int player1Points, int player2Points) =>
            player1Points == player2Points && _player1Points <= 2;

        private bool IsDeuce(int player1Points, int player2Points) =>
            player1Points == player2Points && player1Points > 2;
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