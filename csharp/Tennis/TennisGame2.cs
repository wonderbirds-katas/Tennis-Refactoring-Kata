namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _score1;
        private int _score2;

        public string GetScore()
        {
            if (_score1 == _score2 && _score1 < 3)
                return ScoreAsString(_score1) + "-All";
            if (_score1 == _score2 && _score1 > 2)
                return "Deuce";
            if (_score1 - _score2 == 1 && _score2 >= 3)
                return "Advantage player1";
            if (_score2 - _score1 == 1 && _score1 >= 3)
                return "Advantage player2";
            if (_score1 >= 4 && (_score1 - _score2) >= 2)
                return "Win for player1";
            if (_score2 >= 4 && (_score2 - _score1) >= 2)
                return "Win for player2";

            return ScoreAsString(_score1) + "-" + ScoreAsString(_score2);
        }

        private static string ScoreAsString(int score) =>
            score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };

        public void WonPoint(string player)
        {
            if (player == "player1")
                _score1++;
            else
                _score2++;
        }

    }
}

