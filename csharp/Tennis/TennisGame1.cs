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

        public IGameState AddPointForPlayer1() => new AdvantagePlayer1(_points + 1);

        public IGameState AddPointForPlayer2() => new AdvantagePlayer2(_points + 1);

        public string AsString() => "Deuce";
    }
    
    internal class AdvantagePlayer1 : IGameState
    {
        private readonly int _player1Points;

        public AdvantagePlayer1(int player1Points) => _player1Points = player1Points;

        public IGameState AddPointForPlayer1() => new WinPlayer1();

        public IGameState AddPointForPlayer2() => new Deuce(_player1Points);

        public string AsString() => "Advantage player1";
    }
    
    internal class AdvantagePlayer2 : IGameState
    {
        private readonly int _player2Points;

        public AdvantagePlayer2(int player2Points) => _player2Points = player2Points;

        public IGameState AddPointForPlayer1() => new Deuce(_player2Points);

        public IGameState AddPointForPlayer2() => new GameState(_player2Points - 1, _player2Points + 1);
        
        public string AsString() => "Advantage player2";
    }

    internal class WinPlayer1 : IGameState
    {
        public IGameState AddPointForPlayer1() => new WinPlayer1();

        public IGameState AddPointForPlayer2() => new WinPlayer1();
        
        public string AsString() => "Win for player1";
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
            if (IsAdvantagePlayer1(player1Points, player2Points)) return new AdvantagePlayer1(player1Points);
            if (IsAdvantagePlayer2(player1Points, player2Points)) return new AdvantagePlayer2(player2Points);
            if (IsWinPlayer1(player1Points, player2Points)) return new WinPlayer1();

            return new GameState(player1Points, player2Points);
        }

        public string AsString()
        {
            if (IsWinPlayer2())
                return "Win for player2";

            return _player1Points.AsString() + "-" + _player2Points.AsString();
        }

        private bool IsWinPlayer2()
        {
            return (_player1Points >= 4 || _player2Points >= 4) && _player2Points - _player1Points >= 2;
        }

        private bool IsWinPlayer1(int player1Points, int player2Points)
        {
            return (player1Points >= 4 || player2Points >= 4) && player1Points - player2Points >= 2;
        }

        private bool IsAdvantagePlayer2(int player1Points, int player2Points)
        {
            return (player1Points >= 4 || player2Points >= 4) && player2Points - player1Points == 1;
        }

        private bool IsAdvantagePlayer1(int player1Points, int player2Points)
        {
            return (player1Points >= 4 || player2Points >= 4) && player1Points - player2Points == 1;
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