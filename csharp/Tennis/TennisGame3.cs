namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _score2;
        private int _score1;
        private string _name1;
        private string _name2;

        public TennisGame3(string player1Name, string player2Name)
        {
            _name1 = player1Name;
            _name2 = player2Name;
        }

        public string GetScore()
        {
            if (IsTie()) return ScoreAsString(_score1) + "-All";
            if ((_score1 < 4 && _score2 < 4) && (_score1 + _score2 < 6) && (_score1 != _score2))
                return ScoreAsString(_score1) + "-" + ScoreAsString(_score2);
            if (_score1 == _score2)
                return "Deuce";
            
            var leadPlayerName = _score1 > _score2 ? _name1 : _name2;
            
            if ((_score1 - _score2) * (_score1 - _score2) == 1)
                return "Advantage " + leadPlayerName;
            
            return "Win for " + leadPlayerName;
        }

        private bool IsTie() => _score1 < 4 && _score2 < 4 && _score1 + _score2 < 6 && _score1 == _score2;

        private string ScoreAsString(int score)
        {
            string[] scoreStrings = { "Love", "Fifteen", "Thirty", "Forty" };

            return scoreStrings[score];
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _score1 += 1;
            else
                _score2 += 1;
        }
    }
}

