using System;

namespace LottoPlugin.Models
{
    public class PlayersWinStruct 
    {
        public PlayersWinStruct() {}

        public PlayersWinStruct(string playerName, long playerId, int number, long gain, DateTime gainDateTime, bool recoveGain = false, DateTime recoveDateTime = new DateTime())
        {
            this.playerName = playerName;
            this.playerId = playerId;
            this.number = number;
            this.gain = gain;
            this.gainDateTime = gainDateTime;
            this.recoveGain = recoveGain;
            this.recoveDateTime = recoveDateTime;
        }

        public string playerName;
        public long playerId;
        public int number;
        public long gain;
        public DateTime gainDateTime;
        public bool recoveGain;
        public DateTime recoveDateTime;        
    }
}
