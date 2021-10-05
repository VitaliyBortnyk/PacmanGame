using System;

namespace Pacman
{
    [Serializable]
    class Result
    {
        public string nickname { get; private set; }
        public int score { get; private set; }
        public int attempt { get; private set; }

        public Result(string nickname, int score, int attempt)
        {
            this.nickname = nickname;
            this.score = score;
            this.attempt = attempt;
        }
        ~Result() { }
    }
}
