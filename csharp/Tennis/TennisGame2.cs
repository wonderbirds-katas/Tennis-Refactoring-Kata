namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        public string GetScore()
        {
            if (p1point == p2point && p1point < 3)
                return ScoreAsString(p1point) + "-All";
            if (p1point == p2point && p1point > 2)
                return "Deuce";
            if (p1point - p2point == 1 && p2point >= 3)
                return "Advantage player1";
            if (p2point - p1point == 1 && p1point >= 3)
                return "Advantage player2";
            if (p1point >= 4 && (p1point - p2point) >= 2)
                return "Win for player1";
            if (p2point >= 4 && (p2point - p1point) >= 2)
                return "Win for player2";

            return ScoreAsString(p1point) + "-" + ScoreAsString(p2point);
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

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

