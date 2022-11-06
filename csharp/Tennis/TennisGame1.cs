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
            if (IsTie()) return ScoreAsString(m_score1) + "-" + "All";
            if (IsDeuce()) return "Deuce";
            if (IsAdvantagePlayer1()) return "Advantage player1";
            if (IsAdvantagePlayer2()) return "Advantage player2";
            if (IsWinPlayer1()) return "Win for player1";
            if (IsWinPlayer2()) return "Win for player2";

            return ScoreAsString(m_score1) + "-" + ScoreAsString(m_score2);
        }

        private bool IsWinPlayer1() => m_score1 >= 4 && m_score1 - m_score2 >= 2;
        
        private bool IsWinPlayer2() => m_score2 >= 4 && m_score2 - m_score1 >= 2;
        
        private bool IsAdvantagePlayer1() => m_score1 >= 4 && m_score1 - m_score2 == 1;

        private bool IsAdvantagePlayer2() => m_score2 >= 4 && m_score2 - m_score1 == 1;

        private bool IsTie() => m_score1 == m_score2 && m_score1 <= 2;

        private bool IsDeuce() => m_score1 == m_score2 && m_score1 > 2;

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