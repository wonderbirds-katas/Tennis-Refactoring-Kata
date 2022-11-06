namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (p1point == p2point && p1point < 3)
                return ScoreAsString(p1point) + "-All";
            if (p1point == p2point && p1point > 2)
                return "Deuce";

            if (p1point - p2point == 1 && p2point >= 3)
            {
                return "Advantage player1";
            }
            if (p2point - p1point == 1 && p1point >= 3)
            {
                return "Advantage player2";
            }
            if (p1point >= 4 && (p1point - p2point) >= 2)
            {
                return "Win for player1";
            }
            if (p2point >= 4 && (p2point - p1point) >= 2)
            {
                return "Win for player2";
            }
            
            p2res = ScoreAsString(p2point);
            p1res = ScoreAsString(p1point);
            score = p1res + "-" + p2res;
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
        
        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

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

