namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private GameState _state = new();

        public void WonPoint(string playerName) =>
            _state = playerName switch
            {
                "player1" => _state.AddPointForPlayer1(),
                _ => _state.AddPointForPlayer2()
            };

        public string GetScore() => _state.AsString();
    }

    internal class GameState
    {
        private int Player1Points { get; init; }

        private int Player2Points { get; init; }

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

        private bool IsAdvantageOrWin() => Player1Points >= 4 || Player2Points >= 4;

        private bool IsTie() => Player1Points == Player2Points;

        private bool IsDeuce() => Player1Points == Player2Points && Player1Points > 2;

        public string AsString()
        {
            if (IsDeuce()) return "Deuce";
            if (IsTie()) return ScoreAsString(Player1Points) + "-" + "All";
            if (IsAdvantageOrWin()) return AdvantageOrWinnerAsString();

            return ScoreAsString(Player1Points) + "-" + ScoreAsString(Player2Points);
        }
        
        private string AdvantageOrWinnerAsString() =>
            (Player1Points - Player2Points) switch
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