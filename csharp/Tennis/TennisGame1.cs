namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (IsDeuce()) return "Deuce";
            if (m_score1 == m_score2) return ScoreAsString(m_score1) + "-" + "All";
            if (m_score1 >= 4 || m_score2 >= 4) return AdvantageOrWinnerAsString();

            return ScoreAsString(m_score1) + "-" + ScoreAsString(m_score2);
        }

        private bool IsDeuce()
        {
            return m_score1 == m_score2 && m_score1 > 2;
        }

        private string AdvantageOrWinnerAsString()
        {
            string scoreString;
            var minusResult = m_score1 - m_score2;
            if (minusResult == 1) scoreString = "Advantage player1";
            else if (minusResult == -1) scoreString = "Advantage player2";
            else if (minusResult >= 2) scoreString = "Win for player1";
            else scoreString = "Win for player2";
            return scoreString;
        }

        private static string ScoreAsString(int score)
        {
            var result = "";
            switch (score)
            {
                case 0:
                    result = "Love";
                    break;
                case 1:
                    result = "Fifteen";
                    break;
                case 2:
                    result = "Thirty";
                    break;
                case 3:
                    result = "Forty";
                    break;
            }

            return result;
        }
    }
}