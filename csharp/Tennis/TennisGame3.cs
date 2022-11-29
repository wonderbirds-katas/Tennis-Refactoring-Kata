namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _score2;
        private int _score1;
        private readonly string _name1;
        private readonly string _name2;

        public TennisGame3(string player1Name, string player2Name)
        {
            _name1 = player1Name;
            _name2 = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _score1 += 1;
            else
                _score2 += 1;
        }

        public string GetScore()
        {
            if ((_score1 < 4 && _score2 < 4) && (_score1 + _score2 < 6))
            {
                return (_score1 == _score2) ? ScoreAsString(_score1) + "-All" : ScoreAsString(_score1) + "-" + ScoreAsString(_score2);
            }
            else
            {
                if (_score1 == _score2)
                    return "Deuce";
                return ((_score1 - _score2) * (_score1 - _score2) == 1) ? "Advantage " + LeadPlayerName() : "Win for " + LeadPlayerName();
            }
        }

        private string LeadPlayerName()
        {
            return _score1 > _score2 ? _name1 : _name2;
        }

        private string ScoreAsString(int score)
        {
            return new[] { "Love", "Fifteen", "Thirty", "Forty" }[score];
        }
    }
}
