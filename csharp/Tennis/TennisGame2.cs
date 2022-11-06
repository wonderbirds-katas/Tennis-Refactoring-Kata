namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";

        public string GetScore()
        {
            var score = "";
            if (p1point == p2point && p1point < 3)
                score = ScoreAsString(p1point) + "-All";
            if (p1point == p2point && p1point > 2)
                score = "Deuce";

            if ((p1point > 0 && p2point == 0) || (p2point > 0 && p1point == 0))
            {
                p1res = ScoreAsString(p1point);
                p2res = ScoreAsString(p2point);
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p1point < 4)
            {
                p1res = ScoreAsString(p1point);
                p2res = ScoreAsString(p2point);
                score = p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                p2res = ScoreAsString(p2point);
                p1res = ScoreAsString(p1point);
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
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

