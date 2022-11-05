namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;

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
            if (IsTie()) return ScoreAsString(m_score1) + "-" + "All";
            if (IsAdvantageOrWin()) return AdvantageOrWinnerAsString();

            return ScoreAsString(m_score1) + "-" + ScoreAsString(m_score2);
        }

        private bool IsAdvantageOrWin()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private bool IsTie()
        {
            return m_score1 == m_score2;
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