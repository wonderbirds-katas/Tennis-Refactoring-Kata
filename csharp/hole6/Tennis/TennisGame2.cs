namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _score1;
        private int _score2;

        public void WonPoint(string player)
        {
            if (player == "player1")
                _score1++;
            else
                _score2++;
        }

        public string GetScore()
        {
            if (IsTie()) return ScoreAsString(_score1) + "-All";
            if (IsDeuce()) return "Deuce";
            if (IsAdvantagePlayer1()) return "Advantage player1";
            if (IsAdvantagePlayer2()) return "Advantage player2";
            if (IsWinPlayer1()) return "Win for player1";
            if (IsWinPlayer2()) return "Win for player2";

            return ScoreAsString(_score1) + "-" + ScoreAsString(_score2);
        }
        
        private bool IsTie() => _score1 == _score2 && _score1 < 3;

        private bool IsDeuce() => _score1 == _score2 && _score1 > 2;
        
        private bool IsAdvantagePlayer1() => _score1 - _score2 == 1 && _score2 >= 3;

        private bool IsAdvantagePlayer2() => _score2 - _score1 == 1 && _score1 >= 3;

        private bool IsWinPlayer1() => _score1 >= 4 && (_score1 - _score2) >= 2;

        private bool IsWinPlayer2() => _score2 >= 4 && (_score2 - _score1) >= 2;

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

