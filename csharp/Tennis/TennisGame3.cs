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
            this._name1 = player1Name;
            this._name2 = player2Name;
        }

        public string GetScore()
        {
            string s;
            if ((_score1 < 4 && _score2 < 4) && (_score1 + _score2 < 6))
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[_score1];
                return (_score1 == _score2) ? s + "-All" : s + "-" + p[_score2];
            }
            else
            {
                if (_score1 == _score2)
                    return "Deuce";
                s = _score1 > _score2 ? _name1 : _name2;
                return ((_score1 - _score2) * (_score1 - _score2) == 1) ? "Advantage " + s : "Win for " + s;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this._score1 += 1;
            else
                this._score2 += 1;
        }

    }
}

