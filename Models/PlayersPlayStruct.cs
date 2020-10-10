using System;

namespace LottoPlugin.Models
{
    public struct PlayersPlayStruct
    {
        public PlayersPlayStruct(string playerName, long playerId, int chiffre, DateTime time)
        {
            this.playerName = playerName;
            this.playerId = playerId;
            this.chiffre = chiffre;
            this.time = time;
        }

        public string playerName;
        public long playerId;
        public int chiffre;
        public DateTime time;
    }
}
